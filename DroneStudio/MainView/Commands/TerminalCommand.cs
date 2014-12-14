using System;
using System.Windows.Input;
using DroneStudio.ViewUtils;
using DroneStudio.Modules.Terminal;

namespace DroneStudio.MainView.Commands
{
    public class TerminalCommand : ICommand
    {
        public TerminalCommand(WindowDisplayer windowDisplayer, ITerminalViewFactory terminalViewFactory,
            ITerminalViewModelFactory terminalViewModelFactory)
        {
            this.windowDisplayer = windowDisplayer;
            this.terminalViewFactory = terminalViewFactory;
            this.terminalViewModelFactory = terminalViewModelFactory;
        }

        public void Execute(object parameter)
        {
            var view = this.terminalViewFactory.Create();
            var viewModel = this.terminalViewModelFactory.Create();

            this.windowDisplayer.ShowInFloatingWindow(view, viewModel, "Terminal");
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        private readonly WindowDisplayer windowDisplayer;
        private readonly ITerminalViewFactory terminalViewFactory;
        private readonly ITerminalViewModelFactory terminalViewModelFactory;
    }
}
