using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Project2.Presentation.Views.Converters
{
    [ValueConversion(typeof(object), typeof(bool))]
    public class NullToFalse : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
