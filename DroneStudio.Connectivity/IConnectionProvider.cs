using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connectivity
{
    interface IConnectionProvider
    {
        IObservable<IConnection> Connection { get; }
    }
}
