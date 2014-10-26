using InTheHand.Net.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connections.Bluetooth
{
    public class BluetoothPrimaryRadioProvider : IBluetoothRadioProvider
    {
        public BluetoothRadio BluetoothRadio
        {
            get { return BluetoothRadio.PrimaryRadio; }
        }
    }
}
