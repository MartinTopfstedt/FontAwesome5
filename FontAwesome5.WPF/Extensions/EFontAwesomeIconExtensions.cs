using FontAwesome5.Extensions;
using System.Windows.Media;

namespace FontAwesome5.WPF.Extensions
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

            switch (info.Style)
            {
                case EFontAwesomeStyle.Regular: return Fonts.RegularTypeface;
                case EFontAwesomeStyle.Solid: return Fonts.SolidTypeface;
                case EFontAwesomeStyle.Brands: return Fonts.BrandsTypeface;
            }

            return null;
        }

        /// <summary>
        /// Get the FontFamily of an icon
        /// </summary>
        public static FontFamily GetFontFamily(this EFontAwesomeIcon icon)
        {
            var info = icon.GetInformationAttribute<FontAwesomeInformationAttribute>();
            if (info == null)
                return Fonts.RegularFontFamily;
            
            switch (info.Style)
            {
                case EFontAwesomeStyle.Regular: return Fonts.RegularFontFamily;
                case EFontAwesomeStyle.Solid: return Fonts.SolidFontFamily;
                case EFontAwesomeStyle.Brands: return Fonts.BrandsFontFamily;
            }

            return null;
        }
    }
}
