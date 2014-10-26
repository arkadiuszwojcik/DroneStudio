using DroneStudio.ViewUtils;
using DroneStudio.Modules.Connection;
using System.Windows;
using Fluent;

namespace DroneStudio
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.FixDisappearingDataContextAfterMinimize();
        }

        private void FixDisappearingDataContextAfterMinimize()
        {
            // HACK https://fluent.codeplex.com/workitem/22360
            this.ribbon.IsMinimizedChanged += RibbonIsMinimizedChanged;
            this.ribbon.Tabs.Insert(0, new RibbonTabItem() { Visibility = System.Windows.Visibility.Collapsed });
            this.ribbon.SelectedTabIndex = 1;
        }

        private void RibbonIsMinimizedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.ribbon.IsMinimized == true)
            {
                this.tabIndex = this.ribbon.SelectedTabIndex;
                this.ribbon.SelectedTabIndex = 0;
            }
            else this.ribbon.SelectedTabIndex = this.tabIndex;
        }

        private int tabIndex = 0;
    }
}
