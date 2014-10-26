using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using DroneStudio.Library;

namespace DroneStudio.Connections
{
    public class ConnectionManager : IConnectionProvider
    {
        public ConnectionManager()
        {
            this.connectionSubject = new ReplaySubject<IConnection>(1);
        }

        public Task ConnectAsync(IConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");

            this.Disconnect();

            return connection.ConnectAsync().Then(p => this.NewConnection(connection));
        }

        public void Disconnect()
        {
            this.DisposeConnection();
        }

        public IObservable<IConnection> Connection
        {
            get { return this.connectionSubject; }
        }

        private void DisposeConnection()
        {
            if (this.connection != null)
            {
                this.connection.Dispose();
            }
        }

        private void NewConnection(IConnection newConnection)
        {
            this.connection = newConnection;
            this.connectionSubject.OnNext(connection);
        }

        private IConnection connection;
        private readonly ReplaySubject<IConnection> connectionSubject;
    }
}
