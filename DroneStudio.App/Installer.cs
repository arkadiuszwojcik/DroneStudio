using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DroneStudio.MainView;
using System.Reactive.Concurrency;

namespace DroneStudio
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<DispatcherScheduler>().Instance(DispatcherScheduler.Current));
        }
    }
}
