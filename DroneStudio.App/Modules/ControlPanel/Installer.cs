using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;
using DroneStudio.Modules.ControlPanel.Commands;

namespace DroneStudio.Modules.ControlPanel
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ControlPanelView>().LifestyleTransient());
            container.Register(Component.For<ControlPanelViewModel>().LifestyleTransient());
            container.Register(Component.For<IControlPanelViewFactory>().AsFactory().LifestyleSingleton());
            container.Register(Component.For<IControlPanelViewModelFactory>().AsFactory().LifestyleSingleton());
            container.Register(Component.For<ArmCommand>());
            container.Register(Component.For<DisarmCommand>());
            container.Register(Component.For<ThrottleCommand>());
        }
    }
}
