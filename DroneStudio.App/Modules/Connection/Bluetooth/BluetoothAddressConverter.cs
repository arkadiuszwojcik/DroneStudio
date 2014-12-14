using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace DroneStudio.Modules.Connection.Bluetooth
{
    public class BluetoothAddressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            return Regex.Replace(value.ToString(), ".{2}", "$0:").TrimEnd(new char[] {':'});
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
