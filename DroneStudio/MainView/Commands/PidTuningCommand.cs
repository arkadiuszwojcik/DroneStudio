using DroneStudio.Modules.PidTuner;
using DroneStudio.ViewUtils;
using System;
using System.Windows.Input;

namespace DroneStudio.MainView.Commands
{
    public class PidTuningCommand : ICommand
    {
        public PidTuningCommand(WindowDisplayer windowDisplayer, IPidTunerViewFactory pidTunerViewFactory,
            IPidTunerViewModelFactory pidTunerViewModelFactory)
        {
            this.windowDisplayer = windowDisplayer;
            this.pidTunerViewFactory = pidTunerViewFactory;
            this.pidTunerViewModelFactory = pidTunerViewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var view = this.pidTunerViewFactory.Create();
            var viewModel = this.pidTunerViewModelFactory.Create();

            this.windowDisplayer.ShowInFloatingWindow(view, viewModel, "Pid tuner");
        }

        private readonly WindowDisplayer windowDisplayer;
        private readonly IPidTunerViewFactory pidTunerViewFactory;
        private readonly IPidTunerViewModelFactory pidTunerViewModelFactory;
    }
}
