using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using DroneStudio.MainView;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace DroneStudio
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            this.container = new WindsorContainer();
            this.container.AddFacility<TypedFactoryFacility>();
            this.container.Kernel.Resolver.AddSubResolver(new CollectionResolver(this.container.Kernel, true));
            this.container.Install(FromAssembly.InThisApplication());
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return this.container.Resolve<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
        }

        private readonly WindsorContainer container;
    }
}