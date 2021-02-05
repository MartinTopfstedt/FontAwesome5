using FontAwesome5.Extensions;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace FontAwesome5.Converters
{
    public class StyleConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not EFontAwesomeIcon)
            {
                return EFontAwesomeStyle.None;
            }

            var icon = (EFontAwesomeIcon)value;
            return icon.GetStyle();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
