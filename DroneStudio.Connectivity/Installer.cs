using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DroneStudio.Connectivity.Serial;

namespace DroneStudio.Connectivity
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<SerialPortsProvider>().LifestyleSingleton());
            container.Register(Component.For<SerialBoundRatesProvider>().LifestyleSingleton());
            container.Register(Component.For<SerialConnectionFactory>().LifestyleSingleton());

            container.Register(Component.For<IConnectionProvider, ConnectionManager>().ImplementedBy<ConnectionManager>().LifestyleSingleton());
            container.Register(Component.For<IDataLink>().ImplementedBy<DefaultDataLink>());
        }
    }
}
