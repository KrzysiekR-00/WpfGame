using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Project2.Presentation.Views.Converters
{
    [ValueConversion(typeof(int?), typeof(Visibility))]
    public class IntToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToInt32(value) == System.Convert.ToInt32(parameter))
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
