using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DroneStudio.ViewUtils
{
    public class MessageBoxDisplayer
    {
        public void DisplayErrorMessageBox(string caption, string error)
        {
            System.Windows.MessageBox.Show(error, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
