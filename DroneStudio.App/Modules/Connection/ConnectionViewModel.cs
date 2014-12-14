using DroneStudio.Connections.Serial;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using DroneStudio.Connections;
using DroneStudio.ViewUtils;
using System;
using DroneStudio.Library;
using DroneStudio.Connections.Bluetooth;
using DroneStudio.Modules.Connection.Bluetooth;
using System.Threading.Tasks;

namespace DroneStudio.Modules.Connection
{
    public class ConnectionViewModel : ViewModelBase
    {
        public ConnectionViewModel(
            ConnectionManager connectionManager,
            SerialPortsProvider serialPortsProvider,
            SerialConnectionFactory serialPortConnectionFactory,
            SerialBoundRatesProvider serialPortBoundRatesProvider,
            MessageBoxDisplayer messageBoxDisplayer,
            BluetoothViewModel bluetoothViewModel,
            BluetoothConnectionFactory bluetoothConnectionFactory,
            UiDispatcherProvider uiDispatcherProvider)
        {
            this.SerialPorts = serialPortsProvider.GetPortNames();
            this.BoundRates = serialPortBoundRatesProvider.GetBoundRates();

            this.BluetoothViewModel = bluetoothViewModel;
            this.connectionManager = connectionManager;
            this.serialPortConnectionFactory = serialPortConnectionFactory;
            this.messageBoxDisplayer = messageBoxDisplayer;
            this.bluetoothConnectionFactory = bluetoothConnectionFactory;
            this.uiDispatcherProvider = uiDispatcherProvider;

            this.ConnectCommand = new RelayCommand(this.Connect, this.CanConnect);
            this.DisconnectCommand = new RelayCommand(this.Disconnect, this.CanDisconnect);

            this.SelectedSerialPort = this.SerialPorts.FirstOrDefault();
            this.SelectedBoundRate = this.BoundRates.First();
        }

        public BluetoothViewModel BluetoothViewModel { get; private set; }

        public string[] SerialPorts { get; private set; }

        public int[] BoundRates { get; private set; }

        public string SelectedSerialPort 
        {
            get 
            {
                return this.selectedSerialPort;
            }
            set
            {
                if (this.selectedSerialPort == value) return;
                this.selectedSerialPort = value;
                this.RaisePropertyChanged(() => this.SelectedSerialPort);
                this.ConnectCommand.RaiseCanExecuteChanged();
            }
        }

        public int SelectedBoundRate 
        {
            get
            {
                return this.selectedBoundRate;
            }
            set
            {
                if (this.selectedBoundRate == value) return;
                this.selectedBoundRate = value;
                this.RaisePropertyChanged(() => this.SelectedBoundRate);
                this.ConnectCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsConnected
        {
            get
            {
                return this.isConnected;
            }
            set
            {
                if (this.isConnected == value) return;
                this.isConnected = value;
                this.RaisePropertyChanged(() => this.IsConnected);
                this.ConnectCommand.RaiseCanExecuteChanged();
                this.DisconnectCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand ConnectCommand { get; private set; }
        public RelayCommand DisconnectCommand { get; private set; }

        private void Connect()
        {
            this.SetIsConnecting(true);

            var connection = this.serialPortConnectionFactory.Create(this.SelectedSerialPort, this.selectedBoundRate);

            this.connectionManager
                .ConnectAsync(connection)
                .Then(task => this.SetIsConnected())
                .Finally(this.OnConnectionException, () => this.SetIsConnecting(false));
        }

        private Task SetIsConnected()
        {
            return Task.Factory.StartNew(() => this.uiDispatcherProvider.Dispatcher.Invoke(() => this.IsConnected = true));
        }

        private void SetIsConnecting(bool connecting)
        {
            this.isConnecting = connecting;
            this.uiDispatcherProvider.Dispatcher.Invoke(() => this.ConnectCommand.RaiseCanExecuteChanged());
        }

        private void OnConnectionException(Exception ex)
        {
            this.messageBoxDisplayer.DisplayErrorMessageBox("Connection", ex.Message);
        }

        private bool CanConnect()
        {
            return !this.isConnecting && !this.IsConnected && this.SelectedSerialPort != null;
        }

        private void Disconnect()
        {
            this.connectionManager.Disconnect();
            this.IsConnected = false;
        }

        private bool CanDisconnect()
        {
            return this.IsConnected;
        }

        private string selectedSerialPort;
        private int selectedBoundRate;
        private bool isConnected;
        private bool isConnecting;

        private readonly ConnectionManager connectionManager;
        private readonly SerialConnectionFactory serialPortConnectionFactory;
        private readonly MessageBoxDisplayer messageBoxDisplayer;
        private readonly BluetoothConnectionFactory bluetoothConnectionFactory;
        private readonly UiDispatcherProvider uiDispatcherProvider;
    }
}
