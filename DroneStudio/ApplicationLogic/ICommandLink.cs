using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.ApplicationLogic
{
    public interface ICommandLink
    {
        void SendCommand(string command);
        IObservable<string> IncomingCommands { get; }
    }
}
