using System;
using System.Windows.Input;
using DroneStudio.ApplicationLogic;

namespace DroneStudio.Modules.Settings.Commands
{
    public class LoadCommand : ICommand
    {
        public LoadCommand(ICommandLink commandLink)
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
            this.commandLink.SendCommand("GET\n");
        }

        private readonly ICommandLink commandLink;
    }
}
