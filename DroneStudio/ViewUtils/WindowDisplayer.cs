using GalaSoft.MvvmLight;
using System.Windows;
using System.Windows.Controls;

namespace DroneStudio.ViewUtils
{
    class WindowDisplayer
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
    }
}
