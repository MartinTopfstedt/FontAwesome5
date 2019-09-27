using FontAwesome5.Extensions;
using System.Windows.Media;

namespace FontAwesome5.Extensions
{
    /// <summary>
    /// EFontAwesomeIcon extensions
    /// </summary>
    public static class EFontAwesomeIconExtensions
    {
        /// <summary>
        /// Get the Typeface of an icon
        /// </summary>
        public static Typeface GetTypeFace(this EFontAwesomeIcon icon)
        {
            var info = icon.GetInformationAttribute<FontAwesomeInformationAttribute>();
            if (info == null)
                return Fonts.RegularTypeface;

            return info.Style switch
            {
                EFontAwesomeStyle.Regular => Fonts.RegularTypeface,
                EFontAwesomeStyle.Solid => Fonts.SolidTypeface,
                EFontAwesomeStyle.Brands => Fonts.BrandsTypeface,

                _ => null,
            };
        }

        /// <summary>
        /// Get the FontFamily of an icon
        /// </summary>
        public static FontFamily GetFontFamily(this EFontAwesomeIcon icon)
        {
            var info = icon.GetInformationAttribute<FontAwesomeInformationAttribute>();
            if (info == null)
                return Fonts.RegularFontFamily;

            return info.Style switch
            {
                EFontAwesomeStyle.Regular => Fonts.RegularFontFamily,
                EFontAwesomeStyle.Solid => Fonts.SolidFontFamily,
                EFontAwesomeStyle.Brands => Fonts.BrandsFontFamily,

                _ => null,
            };
        }
    }
}
