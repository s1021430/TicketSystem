using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace TicketSystem.Presentation
{
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bValue = false;
            if (value is bool b)
                bValue = b;
            else
            {
                var tmp = (bool?)value;
                if (value is bool)
                    bValue = tmp.Value;
            }

            return (bValue) ? Visibility.Visible : Visibility.Collapsed;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
                return visibility == Visibility.Visible;
            return false;
        }
    }
    public sealed class BooleanToVisibilityInverseConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bValue = false;
            if (value is bool b)
                bValue = b;
            else
            {
                var tmp = (bool?)value;
                if (value is bool)
                    bValue = tmp.Value;
            }

            return (bValue) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
                return visibility == Visibility.Collapsed;
            return false;
        }
    }
}
