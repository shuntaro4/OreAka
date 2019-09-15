using System;
using System.Globalization;
using System.Windows.Data;

namespace WhatsApp.WPF.Presentation.Converters
{
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var target = value as bool?;
            if (target == null)
            {
                throw new InvalidOperationException();
            }
            return !target;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var target = value as bool?;
            if (target == null)
            {
                throw new InvalidOperationException();
            }
            return !target;
        }
    }
}
