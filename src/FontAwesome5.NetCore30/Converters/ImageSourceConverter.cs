using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace FontAwesome5.Converters
{
    /// <summary>
    /// Converts a FontAwesomIcon to an ImageSource. Use the ConverterParameter to pass the Brush.
    /// </summary>
    public class ImageSourceConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is EFontAwesomeIcon)) return null;


            if (!(parameter is Brush brush))
                brush = Brushes.Black;

            return ImageAwesome.CreateImageSource((EFontAwesomeIcon)value, brush);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
