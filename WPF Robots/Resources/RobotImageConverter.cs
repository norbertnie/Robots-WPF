using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WPF_Robots.Models;

namespace WPF_Robots
{
    public class RobotImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var robot = value as Robot;
            if (robot == null)
                return null;

            // Sprawdź, czy nazwa robota to "Wszystkie"
            if (robot.Name == "Wszystkie")
            {
                return new BitmapImage(new Uri("pack://application:,,,/Images/robot_black.png"));
            }

            // W przeciwnym razie użyj ImagePath robota
            return new BitmapImage(new Uri(robot.ImagePath, UriKind.RelativeOrAbsolute));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
