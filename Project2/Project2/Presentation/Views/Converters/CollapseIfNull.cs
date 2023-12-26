using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Project2.Presentation.Views.Converters
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class CollapseIfNull : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
