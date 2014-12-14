using System;
using DroneStudio.ApplicationLogic.Messages;

namespace DroneStudio.ApplicationLogic
{
    public interface IMessageLink
    {
        IObservable<IMessage> IncomingMessages { get; }
    }
}
