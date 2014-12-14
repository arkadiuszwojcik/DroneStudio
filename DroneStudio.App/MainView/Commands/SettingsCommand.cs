using System;
using System.Windows.Input;
using DroneStudio.ViewUtils;
using DroneStudio.Modules.Settings;

namespace DroneStudio.MainView.Commands
{
    public class SettingsCommand : ICommand
    {
        public SettingsCommand(WindowDisplayer windowDisplayer, ISettingsViewFactory settingsViewFactory,
            ISettingsViewModelFactory settingsViewModelFactory)
        {
            this.windowDisplayer = windowDisplayer;
            this.settingsViewFactory = settingsViewFactory;
            this.settingsViewModelFactory = settingsViewModelFactory;
        }

        public void Execute(object parameter)
        {
            var view = this.settingsViewFactory.Create();
            var viewModel = this.settingsViewModelFactory.Create();

            this.windowDisplayer.ShowInFloatingWindow(view, viewModel, "Settings");
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        private readonly WindowDisplayer windowDisplayer;
        private readonly ISettingsViewFactory settingsViewFactory;
        private readonly ISettingsViewModelFactory settingsViewModelFactory;
    }
}
