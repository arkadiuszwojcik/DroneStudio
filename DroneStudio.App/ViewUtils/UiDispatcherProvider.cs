using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DroneStudio.ViewUtils
{
    public class UiDispatcherProvider : IDispatcherProvider
    {
        public Dispatcher Dispatcher
        {
            get { return Application.Current.Dispatcher; }
        }
    }
}
