using System;
using System.Reactive.Subjects;

namespace DroneStudio.Connectivity
{
    class DefaultDataLink : IDataLink
    {
        public DefaultDataLink(IConnectionProvider connectionProvider)
        {
            this.dataSubject = new Subject<byte[]>();

            connectionProvider.Connection.Subscribe(this.OnNewConnection);
        }

        public void SendData(byte[] data)
        {
            IDataLink dataLink = this.innerDataLink;

            if (dataLink != null)
            {
                dataLink.SendData(data);
            }
        }

        public IObservable<byte[]> DataReceived
        {
            get { return this.dataSubject; }
        }

        private void OnNewConnection(IConnection connection)
        {
            if (connection != null)
            {
                this.innerDataLink = connection.DataLink;
                connection.DataLink.DataReceived.Subscribe(this.OnNewData);
            }
            else
            {
                this.innerDataLink = null;
            }
        }

        private void OnNewData(byte[] data)
        {
            this.dataSubject.OnNext(data);
        }

        private readonly Subject<byte[]> dataSubject;
        private volatile IDataLink innerDataLink;
    }
}
