using DroneStudio.MainView.Commands;
using DroneStudio.Modules.Connection;
using DroneStudio.Modules.Terminal;
using DroneStudio.ViewUtils;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace DroneStudio.MainView
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(ConnectionViewModel connectionViewModel, TerminalCommand terminalCommand,
            ControlPanelCommand controlPanelCommand, PidTuningCommand pidTuningCommand,
            SettingsCommand settingsCommand)
        {
            this.ConnectionsViewModel = connectionViewModel;
            this.TerminalCommand = terminalCommand;
            this.ControlPanelCommand = controlPanelCommand;
            this.PidTuningCommand = pidTuningCommand;
            this.SettingsCommand = settingsCommand;
        }

        public ConnectionViewModel ConnectionsViewModel { get; private set; }

        public ICommand TerminalCommand { get; private set; }

        public ICommand ControlPanelCommand { get; private set; }

        public ICommand PidTuningCommand { get; private set; }

        public ICommand SettingsCommand { get; private set; }
    }
}