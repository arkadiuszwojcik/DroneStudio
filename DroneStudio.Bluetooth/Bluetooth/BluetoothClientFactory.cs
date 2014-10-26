using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connections.Bluetooth
{
    public class BluetoothClientFactory : IBluetoothClientFactory
    {
        public BluetoothClientFactory(IBluetoothRadioProvider bluetootRadioProvider)
        {
            this.bluetootRadioProvider = bluetootRadioProvider;
        }

        public BluetoothClient Create()
        {
            if (this.bluetootRadioProvider.BluetoothRadio == null) return null;

            var localAddress = this.bluetootRadioProvider.BluetoothRadio.LocalAddress;

            if (localAddress == null) return null;

            var localEndpoint = new BluetoothEndPoint(localAddress, BluetoothService.SerialPort);
            return new BluetoothClient(localEndpoint);
        }

        private readonly IBluetoothRadioProvider bluetootRadioProvider;
    }
}
