using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connectivity.Serial
{
    public class SerialConnectionFactory
    {
        public IConnection Create(string portName, int portBoundRate)
        {
            return new SerialConnection(portName, portBoundRate);
        }
    }
}
