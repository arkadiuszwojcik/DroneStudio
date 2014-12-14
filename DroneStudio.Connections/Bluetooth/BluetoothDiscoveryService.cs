using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using DroneStudio.Library;

namespace DroneStudio.Connections.Bluetooth
{
    public class BluetoothDiscoveryService : IBluetoothDiscoveryService
    {
        public BluetoothDiscoveryService(IBluetoothClientFactory bluetoothClientFactory)
        {
            this.bluetoothClientFactory = bluetoothClientFactory;
        }

        public IObservable<BluetoothDeviceInfo> Discover(BluetoothDiscoveryCriteria criteria)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return Observable.Using(this.CreateBluetoothClient, c => this.CreateBluetoothDiscoveryObservable(c, criteria));
        }

        private BluetoothClient CreateBluetoothClient()
        {
            return this.bluetoothClientFactory.Create();
        }

        private IObservable<BluetoothDeviceInfo> CreateBluetoothDiscoveryObservable(BluetoothClient client, BluetoothDiscoveryCriteria criteria)
        {
            return Observable.Create<BluetoothDeviceInfo>(observer => this.CreateObservable(observer, client, criteria));
        }

        private IDisposable CreateObservable(IObserver<BluetoothDeviceInfo> observer, BluetoothClient client, BluetoothDiscoveryCriteria criteria)
        {
            if (client == null)
            {
                observer.OnError(new NullReferenceException("Cant create bluetooth client"));
                return Disposable.Empty;
            }

            var localComponent = new BluetoothComponent(client);

            var discoverProgress = Observable.FromEventPattern<DiscoverDevicesEventArgs>(h => localComponent.DiscoverDevicesProgress += h,
                h => localComponent.DiscoverDevicesProgress -= h);

            var discoverComplete = Observable.FromEventPattern<DiscoverDevicesEventArgs>(h => localComponent.DiscoverDevicesComplete += h,
                h=>localComponent.DiscoverDevicesComplete -= h);

            var discoverProgressSubscription = discoverProgress.Subscribe(args => this.PushNewDevices(observer, args.EventArgs));
            var discoverCompleteSubscription = discoverComplete.Subscribe(args => observer.OnCompleted());

            localComponent.DiscoverDevicesAsync(criteria.MaxDevices, criteria.Authenticated,
                criteria.Remembered, criteria.Unknown, criteria.DiscoverableOnly, null);

            return new CompositeDisposable(discoverProgressSubscription, discoverCompleteSubscription, localComponent);
        }

        private void PushNewDevices(IObserver<BluetoothDeviceInfo> observer, DiscoverDevicesEventArgs args)
        {
            if (args.Devices == null) return;
            args.Devices.ForEach(device => observer.OnNext(device));
        }

        private readonly IBluetoothClientFactory bluetoothClientFactory;
    }
}
