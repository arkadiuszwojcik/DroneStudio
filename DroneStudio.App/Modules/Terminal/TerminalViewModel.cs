using System;
using DroneStudio.ApplicationLogic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

namespace DroneStudio.Modules.Terminal
{
    public class TerminalViewModel : ViewModelBase
    {
        public TerminalViewModel(ICommandLink commandLink, IScheduler dispatcherScheduler)
        {
            this.Lines = new ObservableCollection<string>();
            this.EnterLineCommand = new RelayCommand<string>(NewUserCommand, _ => true);

            this.commandLink = commandLink;
            this.commandLink.IncomingCommands
                .ObserveOn(dispatcherScheduler)
                .Subscribe(OnNewCommand);
        }

        public ObservableCollection<string> Lines { get; private set; }

        public ICommand EnterLineCommand { get; private set; }

        private void NewUserCommand(string command)
        {
            this.AddLine(command);
            this.commandLink.SendCommand(command + '\n');
        }

        private void AddLine(string line)
        {
            this.RemoveFirstLineIfLimitReached();
            this.Lines.Add(line);
        }

        private void RemoveFirstLineIfLimitReached()
        {
            if (this.Lines.Count >= MaxLines)
            {
                this.Lines.RemoveAt(0);
            }
        }

        private void OnNewCommand(string command)
        {
            this.AddLine(command);
        }

        private const int MaxLines = 100;
        private readonly ICommandLink commandLink;
    }
}
