using Castle.Windsor;
using Castle.Windsor.Installer;
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