using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connectivity.Serial
{
    class SerialConnection : IConnection, IDataLink
    {
        public SerialConnection(string name, int boundRate)
        {
            this.serialPort = new System.IO.Ports.SerialPort(name, boundRate);
            this.dataReceived = this.CreatePortObservable();
        }

        #region IConnection

        public Task ConnectAsync()
        {
            return Task.Factory.StartNew(() => this.serialPort.Open());
        }

        public void Disconnect()
        {
            this.serialPort.Close();
        }

        public bool IsConnected
        {
            get { return this.serialPort.IsOpen; }
        }

        public IDataLink DataLink
        {
            get { return this; }
        }

        #endregion

        #region IDataLink

        public void SendData(byte[] data)
        {
            try
            {
                this.serialPort.Write(data, 0, data.Length);
            }
            catch (IOException)
            {
                // TODO Log exception
            }
        }

        public IObservable<byte[]> DataReceived
        {
            get { return this.dataReceived; }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            this.serialPort.Dispose();
        }

        #endregion

        private IObservable<byte[]> CreatePortObservable()
        {
            return Observable.Create<byte[]>(obs =>
            {
                var rcv = this.CreateReceivedHandler(obs);
                var err = this.CreateErrorObservable(obs);

                this.serialPort.DataReceived += rcv;
                this.serialPort.ErrorReceived += err;

                return () =>
                {
                    this.serialPort.DataReceived -= rcv;
                    this.serialPort.ErrorReceived -= err;
                    // depending on ownership of port, you could Dispose it here too
                };
            });
        }

        private SerialDataReceivedEventHandler CreateReceivedHandler(IObserver<byte[]> obs)
        {
            var rcv = new SerialDataReceivedEventHandler((sender, e) =>
            {
                if (e.EventType == SerialData.Eof)
                {
                    obs.OnCompleted();
                }
                else
                {
                    var buf = new byte[this.serialPort.BytesToRead];
                    this.serialPort.Read(buf, 0, buf.Length);
                    obs.OnNext(buf);
                }
            });

            return rcv;
        }

        private SerialErrorReceivedEventHandler CreateErrorObservable(IObserver<byte[]> obs)
        {
            var err = new SerialErrorReceivedEventHandler((sender, e) =>
            {
                obs.OnError(new Exception(e.EventType.ToString()));
            });

            return err;
        }

        private readonly IObservable<byte[]> dataReceived;
        private readonly System.IO.Ports.SerialPort serialPort;
    }
}
