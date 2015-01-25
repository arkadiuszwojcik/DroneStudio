using System;
using DroneStudio.ApplicationLogic.Messages;

namespace DroneStudio.ApplicationLogic
{
    public interface IMessageLink
    {
        void SendMessage(IMessage message);
        IObservable<IMessage> IncomingMessages { get; }
    }
}
