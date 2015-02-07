using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connectivity
{
    public interface IConnection : IDisposable
    {
        Task ConnectAsync();
        void Disconnect();
        bool IsConnected { get; }
        IDataLink DataLink { get; }
    }
}
