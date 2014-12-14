using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.Connections
{
    /*
    public class ConnectionStatusProvider
    {
        public ConnectionStatusProvider(IConnectionProvider connectionProvider)
        {
            this.connectionStatus = new ReplaySubject<bool>(1);
            Observable.Timer(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(3)).Subscribe()
            connectionProvider.Connection.Subscribe(OnNewConnection);
        }

        public IObservable<bool> ConnectionStatus { get; private set; }

        private void OnNewConnection(IConnection connection)
        {
            this.connection = connection;
        }

        private void OnNewTick()
        {
            var connection = this.connection;
            if (co)
        }

        private IConnection connection;
        private readonly ReplaySubject<bool> connectionStatus;
    }
     */
}
