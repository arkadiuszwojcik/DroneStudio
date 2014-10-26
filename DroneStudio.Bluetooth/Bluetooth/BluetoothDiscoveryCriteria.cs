using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connections.Bluetooth
{
    public class BluetoothDiscoveryCriteria
    {
        public int MaxDevices { get; set; }
        public bool Authenticated { get; set; }
        public bool Remembered { get; set; }
        public bool Unknown { get; set; }
        public bool DiscoverableOnly { get; set; } 
    }
}
