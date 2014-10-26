using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneStudio.ViewUtils
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<WindowDisplayer>().LifestyleSingleton());
            container.Register(Component.For<MessageBoxDisplayer>().LifestyleSingleton());
            container.Register(Component.For<UiDispatcherProvider>().LifestyleSingleton());
        }
    }
}
