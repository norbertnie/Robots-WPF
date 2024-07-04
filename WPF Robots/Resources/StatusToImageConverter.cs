using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WPF_Robots.Converters
{
    public class StatusToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                switch (status)
                {
                    case "Dostępny":
                        return new BitmapImage(new Uri("pack://application:,,,/Images/check.png"));
                    case "W trakcie akcji":
                        return new BitmapImage(new Uri("pack://application:,,,/Images/arrows.png"));
                    case "Niedostępny zajęty":
                        return new BitmapImage(new Uri("pack://application:,,,/Images/warning.png"));
                    case "Niedostępny Potrzebny asystent":
                        return new BitmapImage(new Uri("pack://application:,,,/Images/error.png"));
                    default:
                        return null;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
