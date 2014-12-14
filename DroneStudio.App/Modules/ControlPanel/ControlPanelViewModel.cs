using DroneStudio.Modules.ControlPanel.Commands;
using GalaSoft.MvvmLight;
using System.Windows.Input;

namespace DroneStudio.Modules.ControlPanel
{
    public class ControlPanelViewModel : ViewModelBase
    {
        public ControlPanelViewModel(ArmCommand armCommand, DisarmCommand disarmCommand, ThrottleCommand throttleCommand)
        {
            this.ArmCommand = armCommand;
            this.DisarmCommand = disarmCommand;
            this.ThrottleCommand = throttleCommand; 
        }

        public ICommand ArmCommand { get; private set; }

        public ICommand DisarmCommand { get; private set; }

        public ICommand ThrottleCommand { get; private set; }

        public int EnginesPower 
        {
            get { return this.enginesPower; }
            set
            {
                if (this.enginesPower == value) return;
                this.enginesPower = value;
                this.RaisePropertyChanged(() => this.EnginesPower);
                this.ThrottleCommand.Execute(value);
            }
        }

        private int enginesPower = 0;
    }
}
