using DroneStudio.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.ApplicationLogic
{
    class CommandLink : ICommandLink
    {
        public CommandLink(IDataLink dataLink)
        {
            this.dataLink = dataLink;
            this.incomingCommands = new Subject<string>();

            this.dataLink.DataReceived.Subscribe(this.OnNewData);
        }

        public void SendCommand(string command)
        {
            this.dataLink.SendData(Encoding.ASCII.GetBytes(command));
        }

        public IObservable<string> IncomingCommands
        {
            get { return this.incomingCommands; }
        }

        private void OnNewData(byte[] newData)
        {
            for (int i = 0; i <newData.Length; i++)
            {
                byte b = newData[i];
                if (b == Delimiter)
                {
                    string command = Encoding.ASCII.GetString(buffer, 0, this.bufferPosition);
                    this.bufferPosition = 0;
                    this.incomingCommands.OnNext(command);
                }
                else
                {
                    this.buffer[this.bufferPosition++] = b;
                }
            }
        }

        private const byte Delimiter = (byte)'\n';
        private const int BufferSize = 2048;

        private int bufferPosition = 0;
        private readonly byte[] buffer = new byte[BufferSize];

        private readonly IDataLink dataLink;
        private readonly Subject<string> incomingCommands;
    }
}
