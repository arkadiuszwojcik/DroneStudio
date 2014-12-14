using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;
using System.Reactive.Concurrency;

namespace DroneStudio.Modules.Terminal
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<TerminalView>().LifestyleTransient());
            container.Register(Component.For<TerminalViewModel>().LifestyleTransient()
                .DependsOn(Dependency.OnComponent<IScheduler, DispatcherScheduler>()));
            container.Register(Component.For<ITerminalViewFactory>().AsFactory().LifestyleSingleton());
            container.Register(Component.For<ITerminalViewModelFactory>().AsFactory().LifestyleSingleton());
        }
    }
}
