using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using DroneStudio.Connectivity;

namespace DroneStudio.ApplicationLogic
{
    class CommandLink : ICommandLink
    {
        public CommandLink(IDataLink dataLink)
        {
            this.dataLink = dataLink;
            this.incomingCommands = new Subject<string>();

            this.dataLink.DataReceived.Subscribe(this.OnNewData);

            /*
            var thread = new System.Threading.Thread(() => {
                System.Threading.Thread.Sleep(10000);
                this.incomingCommands.OnNext("PIDM 20");
                this.incomingCommands.OnNext("PIDM 20");
                this.incomingCommands.OnNext("PIDM 20");
                this.incomingCommands.OnNext("FV 0 33");
                this.incomingCommands.OnNext("FV 8 44");
                this.incomingCommands.OnNext("PID A 1 2 3 4");
                this.incomingCommands.OnNext("PID B 5 6 7 8");
                this.incomingCommands.OnNext("PID C 9 10 11 12");
                this.incomingCommands.OnNext("PID D 13 14 15 16");
                this.incomingCommands.OnNext("PID E 17 18 19 20");
                this.incomingCommands.OnNext("PID F 21 22 23 24");
            });
            thread.Start();
            */
           
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
