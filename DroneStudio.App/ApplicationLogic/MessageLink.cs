using System;
using System.Linq;
using System.Reactive.Subjects;
using DroneStudio.Library;
using DroneStudio.ApplicationLogic.Messages;
using System.Collections.Generic;

namespace DroneStudio.ApplicationLogic
{
    public class MessageLink : IMessageLink
    {
        public MessageLink(ICommandLink commandLink, IEnumerable<IMessageParser> messageParsers)
        {
            this.commandLink = commandLink;
            this.messageParsers = messageParsers;
            this.incomingMessages = new Subject<IMessage>();

            this.commandLink.IncomingCommands.Subscribe(this.OnNewCommand);
        }

        public void SendMessage(IMessage message)
        {
            this.commandLink.SendCommand(message.ToString());
        }

        public IObservable<IMessage> IncomingMessages
        {
            get { return this.incomingMessages; }
        }

        private void OnNewCommand(string command)
        {
            this.messageParsers
                .Select(p => p.TryParse(command))
                .WhereNotNull()
                .ForEach(p => this.incomingMessages.OnNext(p));
        }

        private readonly Subject<IMessage> incomingMessages;
        private readonly ICommandLink commandLink;
        private readonly IEnumerable<IMessageParser> messageParsers;
    }
}
