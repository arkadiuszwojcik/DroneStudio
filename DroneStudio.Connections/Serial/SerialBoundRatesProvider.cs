using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connections.Serial
{
    public class SerialBoundRatesProvider
    {
        public int[] GetBoundRates()
        {
            return new int[] { 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200 }; 
        }
    }
}
