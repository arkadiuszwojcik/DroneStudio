using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DroneStudio.MainView.Commands;

namespace DroneStudio.MainView
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<MainViewModel>());
            container.Register(Component.For<TerminalCommand>());
            container.Register(Component.For<ControlPanelCommand>());
            container.Register(Component.For<PidTuningCommand>());
            container.Register(Component.For<SettingsCommand>());
        }
    }
}
