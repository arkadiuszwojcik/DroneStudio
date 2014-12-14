using System;
using System.Windows.Input;
using DroneStudio.ApplicationLogic;

namespace DroneStudio.Modules.ControlPanel.Commands
{
    public class ThrottleCommand : ICommand
    {
        public ThrottleCommand(ICommandLink commandLink)
        {
            this.commandLink = commandLink;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            int value = (int)parameter;
            this.commandLink.SendCommand(String.Format("TH {0}\n", value));
        }

        private readonly ICommandLink commandLink;
    }
}
