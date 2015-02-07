using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connectivity
{
    public interface IDataLink
    {
        void SendData(byte[] data);
        IObservable<byte[]> DataReceived { get; }
    }
}
