using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_Robots.Converters
{
    public class StatusToBorderBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                switch (status)
                {
                    case "W trakcie akcji":
                        return Brushes.Blue;
                    case "Dostępny":
                        return Brushes.Green;
                    case "Niedostępny zajęty":
                        return Brushes.Orange;
                    case "Niedostępny Potrzebny asystent":
                        return Brushes.Red;
                    default:
                        return Brushes.Black;
                }
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
