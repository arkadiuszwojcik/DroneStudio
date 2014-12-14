using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connections.Bluetooth
{
    public interface IBluetoothDiscoveryService
    {
        IObservable<BluetoothDeviceInfo> Discover(BluetoothDiscoveryCriteria criteria);
    }
}
