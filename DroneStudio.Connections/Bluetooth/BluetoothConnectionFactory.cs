using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace DroneStudio.Connections.Bluetooth
{
    public class BluetoothConnectionFactory
    {
        public BluetoothConnectionFactory(IBluetoothClientFactory bluetoothClientFactory)
        {
            this.bluetoothClientFactory = bluetoothClientFactory;
        }

        public IConnection Create(BluetoothDeviceInfo deviceInfo)
        {
            var client = this.bluetoothClientFactory.Create();
            return new BluetoothConnection(client, new BluetoothEndPoint(deviceInfo.DeviceAddress, BluetoothService.SerialPort));
        }

        private readonly IBluetoothClientFactory bluetoothClientFactory;
    }
}
