using DroneStudio.Modules.Connection;
using DroneStudio.Modules.Tools.Terminal;
using DroneStudio.ViewUtils;
using GalaSoft.MvvmLight;

namespace DroneStudio
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(ConnectionViewModel connectionViewModel, TerminalViewModel terminalViewModel)
        {
            this.ConnectionsViewModel = connectionViewModel;
            this.TerminalViewModel = terminalViewModel;
        }

        public ConnectionViewModel ConnectionsViewModel { get; private set; }
        public TerminalViewModel TerminalViewModel { get; private set; }
    }
}