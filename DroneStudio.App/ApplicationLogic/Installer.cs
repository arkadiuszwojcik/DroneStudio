using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using DroneStudio.ApplicationLogic.Messages;

namespace DroneStudio.ApplicationLogic
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMessageParser>().ImplementedBy<PidMeasureMessageParser>());

            container.Register(Component.For<ICommandLink>().ImplementedBy<CommandLink>());
            container.Register(Component.For<IMessageLink>().ImplementedBy<MessageLink>());
        }
    }
}
