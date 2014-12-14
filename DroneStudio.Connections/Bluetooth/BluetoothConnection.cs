using InTheHand.Net;
using InTheHand.Net.Sockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
namespace DroneStudio.Connections.Bluetooth
{
    public class BluetoothConnection : IConnection
    {
        public BluetoothConnection(BluetoothClient bluetoothClient, BluetoothEndPoint bluetoothEndPoint)
        {
            this.bluetoothClient = bluetoothClient;
            this.bluetoothEndPoint = bluetoothEndPoint;
        }

        public Task ConnectAsync()
        {
            var connectionTask = Task.Factory.FromAsync<BluetoothEndPoint>(this.bluetoothClient.BeginConnect, this.bluetoothClient.EndConnect, bluetoothEndPoint, null);
            connectionTask.Start();
            return connectionTask;
        }

        public void Disconnect()
        {
            this.bluetoothClient.Close();
        }

        public bool IsConnected
        {
            get { throw new System.NotImplementedException(); }
        }

        public IDataLink DataLink
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        private readonly BluetoothClient bluetoothClient;
        private readonly BluetoothEndPoint bluetoothEndPoint;
    }
}
