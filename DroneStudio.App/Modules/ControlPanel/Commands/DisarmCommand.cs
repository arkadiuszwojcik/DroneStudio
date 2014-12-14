using System;
using System.Windows.Input;
using DroneStudio.ApplicationLogic;

namespace DroneStudio.Modules.ControlPanel.Commands
{
    public class DisarmCommand : ICommand
    {
        public DisarmCommand(ICommandLink commandLink)
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
            this.commandLink.SendCommand("DARM\n");
        }

        private readonly ICommandLink commandLink;
    }
}
