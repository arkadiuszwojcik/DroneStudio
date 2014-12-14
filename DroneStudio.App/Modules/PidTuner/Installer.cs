using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;
using System.Reactive.Concurrency;

namespace DroneStudio.Modules.PidTuner
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<PidTunerView>().LifestyleTransient());
            container.Register(Component.For<PidTunerViewModel>().LifestyleTransient()
                .DependsOn(Dependency.OnComponent<IScheduler, DispatcherScheduler>()));
            container.Register(Component.For<IPidTunerViewFactory>().AsFactory().LifestyleSingleton());
            container.Register(Component.For<IPidTunerViewModelFactory>().AsFactory().LifestyleSingleton());
        }
    }
}
