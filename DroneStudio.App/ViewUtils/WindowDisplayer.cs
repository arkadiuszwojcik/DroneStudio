using GalaSoft.MvvmLight;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;

namespace DroneStudio.ViewUtils
{
    public class WindowDisplayer
    {
        public void ShowInDialog(string title, UserControl control, ViewModelBase viewModel, int width, int height)
        {
            var window = new Window();

            control.DataContext = viewModel;

            if (viewModel is ICloseableViewModel)
            {
                (viewModel as ICloseableViewModel).ClosingRequest += (sender, e) => window.Close();
            }

            window.Title = title;
            window.Content = control;
            window.WindowStyle = WindowStyle.ToolWindow;
            window.ResizeMode = ResizeMode.NoResize;
            window.Width = width;
            window.Height = height;
            window.Show();
        }

        public void ShowInDialog(string title, UserControl control, ViewModelBase viewModel)
        {
            this.ShowInDialog(title, control, viewModel, 300, 300);
        }

        public void ShowInFloatingWindow(UserControl control, ViewModelBase viewModel, string title)
        {
            control.DataContext = viewModel;

            var layout = new LayoutAnchorable();
            layout.Title = title;
            layout.Content = control;
            layout.AddToLayout(AvalonDockingManager.Instance.DockingManager, AnchorableShowStrategy.Most);
            layout.FloatingWidth = 300;
            layout.FloatingHeight = 300;
            layout.Float();
        }
    }
}
