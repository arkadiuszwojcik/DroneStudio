using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DroneStudio.Connections.Bluetooth;
using DroneStudio.Connections.Serial;

namespace DroneStudio.Connections
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<SerialPortsProvider>().LifestyleSingleton());
            container.Register(Component.For<SerialBoundRatesProvider>().LifestyleSingleton());
            container.Register(Component.For<SerialConnectionFactory>().LifestyleSingleton());

            container.Register(Component.For<IBluetoothRadioProvider>().ImplementedBy<BluetoothPrimaryRadioProvider>().LifestyleSingleton());
            container.Register(Component.For<IBluetoothClientFactory>().ImplementedBy<BluetoothClientFactory>().LifestyleSingleton());
            container.Register(Component.For<IBluetoothDiscoveryService>().ImplementedBy<BluetoothDiscoveryService>().LifestyleSingleton());
            container.Register(Component.For<BluetoothConnectionFactory>().LifestyleSingleton());

            container.Register(Component.For<IConnectionProvider, ConnectionManager>().ImplementedBy<ConnectionManager>().LifestyleSingleton());
            container.Register(Component.For<IDataLink>().ImplementedBy<DefaultDataLink>());
        }
    }
}
