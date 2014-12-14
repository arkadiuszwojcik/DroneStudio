using System;
using System.Linq;
using DroneStudio.Connections.Bluetooth;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InTheHand.Net.Sockets;
using DroneStudio.ViewUtils;
using System.Collections.ObjectModel;
using InTheHand.Net;
using DroneStudio.ApplicationLogic;

namespace DroneStudio.Modules.Connection.Bluetooth
{
    public class BluetoothViewModel : ViewModelBase
    {
        public BluetoothViewModel(
            IBluetoothDiscoveryService bluetoothDiscoveryService,
            UiDispatcherProvider uiDispatcherProvider,
            MessageBoxDisplayer messageBoxDisplayer)
        {
            this.bluetoothDiscoveryService = bluetoothDiscoveryService;
            this.uiDispatcherProvider = uiDispatcherProvider;
            this.messageBoxDisplayer = messageBoxDisplayer;

            this.DiscoverCommand = new RelayCommand(this.CommandDiscover, this.CommandCanDiscover);
            this.Devices = new ObservableCollection<BluetoothDeviceInfo>();
        }

        public RelayCommand DiscoverCommand { get; private set; }

        public ObservableCollection<BluetoothDeviceInfo> Devices { get; private set; }

        public BluetoothDeviceInfo SelectedBluetoothDevice { get; set; }

        public bool CanDiscover
        {
            get
            {
                return this.canDiscover;
            }
            set
            {
                if (this.canDiscover == value) return;
                this.canDiscover = value;
                this.RaisePropertyChanged(() => this.CanDiscover);
                this.DiscoverCommand.RaiseCanExecuteChanged();
            }
        }

        private void CommandDiscover()
        {
            var discoveryCriteria = new BluetoothDiscoveryCriteria() { MaxDevices = 255, Remembered = true, Unknown = true };

            this.CanDiscover = false;
            this.Devices.Clear();

            this.bluetoothDiscoveryService.Discover(discoveryCriteria)
                .Subscribe(this.OnDiscover, this.OnDiscoverError, this.OnDiscoverCompleted);
        }

        private void OnCommand(string cmd)
        {

        }

        private bool CommandCanDiscover()
        {
            return this.CanDiscover;
        }

        private void OnDiscover(BluetoothDeviceInfo deviceInfo)
        {
            this.uiDispatcherProvider.Dispatcher.Invoke(() => this.Devices.Add(deviceInfo));
        }

        private void OnDiscoverCompleted()
        {
            this.uiDispatcherProvider.Dispatcher.Invoke(() => this.CanDiscover = true);
        }

        private void OnDiscoverError(Exception ex)
        {
            this.uiDispatcherProvider.Dispatcher.Invoke(() => this.OnError(ex));
        }

        private void OnError(Exception ex)
        {
            this.CanDiscover = true;
            this.messageBoxDisplayer.DisplayErrorMessageBox("Bluetooth", ex.Message);
        }

        private bool canDiscover = true;
        private readonly UiDispatcherProvider uiDispatcherProvider;
        private readonly MessageBoxDisplayer messageBoxDisplayer;
        private readonly IBluetoothDiscoveryService bluetoothDiscoveryService;
    }
}
