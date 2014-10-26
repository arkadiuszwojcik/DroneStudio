using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DroneStudio.Modules.Tools.Terminal;
using System.Reactive.Concurrency;

namespace DroneStudio
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<DispatcherScheduler>().Instance(DispatcherScheduler.Current));
            container.Register(Component.For<MainViewModel>());
            container.Register(Component.For<TerminalViewModel>()
                .DependsOn(Dependency.OnComponent<IScheduler, DispatcherScheduler>()));
        }
    }
}
