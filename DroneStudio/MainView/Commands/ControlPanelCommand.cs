using DroneStudio.Modules.ControlPanel;
using DroneStudio.ViewUtils;
using System;
using System.Windows.Input;

namespace DroneStudio.MainView.Commands
{
    public class ControlPanelCommand : ICommand
    {
        public ControlPanelCommand(WindowDisplayer windowDisplayer, IControlPanelViewFactory controlPanelViewFactory,
            IControlPanelViewModelFactory controlPanelViewModelFactory)
        {
            this.windowDisplayer = windowDisplayer;
            this.controlPanelViewFactory = controlPanelViewFactory;
            this.controlPanelViewModelFactory = controlPanelViewModelFactory;
        }

        public void Execute(object parameter)
        {
            var view = this.controlPanelViewFactory.Create();
            var viewModel = this.controlPanelViewModelFactory.Create();

            this.windowDisplayer.ShowInFloatingWindow(view, viewModel, "Control panel");
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        private readonly WindowDisplayer windowDisplayer;
        private readonly IControlPanelViewFactory controlPanelViewFactory;
        private readonly IControlPanelViewModelFactory controlPanelViewModelFactory;
    }
}
