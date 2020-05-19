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
            if (!(value is EFontAwesomeIcon))
                return null;

            var icon = (EFontAwesomeIcon)value;
            var info = icon.GetInformationAttribute<FontAwesomeInformationAttribute>();
            if (info == null)
                return null; 

            if (parameter is string format && !string.IsNullOrEmpty(format))
            {
                return string.Format(format, info.Label, info.Style);
            }

            return info.Label;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
