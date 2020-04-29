using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace FontAwesome5.Converters
{    
    [ValueConversion(typeof(EFontAwesomeIcon), typeof(Visibility))]
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is EFontAwesomeIcon))
                throw new InvalidOperationException("The target must be a EFontAwesomeIcon");

            if ((EFontAwesomeIcon)value == EFontAwesomeIcon.None)
            {
                return parameter ?? Visibility.Collapsed;
            }

            return Visibility.Visible;
        }
        

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
