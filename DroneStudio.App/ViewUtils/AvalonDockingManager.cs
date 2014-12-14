using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock;

namespace DroneStudio.ViewUtils
{
    public sealed class AvalonDockingManager
    {
        private static readonly AvalonDockingManager instance = new AvalonDockingManager();

        private AvalonDockingManager() { }

        public static AvalonDockingManager Instance
        {
            get { return instance; }
        }

        public void AddDockingManager(DockingManager dockingManager)
        {
            this.DockingManager = dockingManager;
        }

        public DockingManager DockingManager { get; private set; }
    }
}
