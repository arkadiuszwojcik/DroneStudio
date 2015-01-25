using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;
using DroneStudio.Modules.Settings.Commands;
using DroneStudio.Modules.Settings.Views;
using DroneStudio.Modules.Settings.ViewModels;

namespace DroneStudio.Modules.Settings
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<LoadCommand>().LifestyleTransient());
            container.Register(Component.For<SaveCommand>().LifestyleTransient());
            container.Register(Component.For<SettingsView>().LifestyleTransient());
            container.Register(Component.For<SettingsViewModel>().LifestyleTransient());
            container.Register(Component.For<ISettingsViewFactory>().AsFactory().LifestyleSingleton());
            container.Register(Component.For<ISettingsViewModelFactory>().AsFactory().LifestyleSingleton());
            container.Register(Component.For<ISettingsModel>().ImplementedBy<SettingsModel>().LifestyleSingleton());
        }
    }
}
