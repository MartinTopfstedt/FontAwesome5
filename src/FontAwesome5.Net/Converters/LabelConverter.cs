using FontAwesome5.Extensions;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace FontAwesome5.Converters
{
    public class LabelConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not EFontAwesomeIcon)
            {
                return null;
            }

            var icon = (EFontAwesomeIcon)value;
            var info = icon.GetInformation();
            if (info == null)
            {
                return null;
            }

            return parameter is string format && !string.IsNullOrEmpty(format) ? string.Format(format, info.Label, info.Style) : info.Label;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
