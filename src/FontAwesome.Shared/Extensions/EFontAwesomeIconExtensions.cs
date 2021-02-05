using FontAwesome5.Extensions;
#if WINDOWS_UWP
using Windows.UI.Xaml.Media;
#else
using System.Windows.Media;
#endif
namespace FontAwesome5.Extensions
{
    /// <summary>
    /// EFontAwesomeIcon extensions
    /// </summary>
    public static class EFontAwesomeIconExtensions
    {
#if !WINDOWS_UWP
        /// <summary>
        /// Get the Typeface of an icon
        /// </summary>
        public static Typeface GetTypeFace(this EFontAwesomeIcon icon)
        {
            switch (icon.GetStyle())
            {
                case EFontAwesomeStyle.Regular: return Fonts.RegularTypeface;
                case EFontAwesomeStyle.Solid: return Fonts.SolidTypeface;
                case EFontAwesomeStyle.Brands: return Fonts.BrandsTypeface;
            }

            return Fonts.RegularTypeface;
        }
#endif
        /// <summary>
        /// Get the FontFamily of an icon
        /// </summary>
        public static FontFamily GetFontFamily(this EFontAwesomeIcon icon)
        {
            switch (icon.GetStyle())
            {
                case EFontAwesomeStyle.Regular: return Fonts.RegularFontFamily;
                case EFontAwesomeStyle.Solid: return Fonts.SolidFontFamily;
                case EFontAwesomeStyle.Brands: return Fonts.BrandsFontFamily;   
            }

            return Fonts.RegularFontFamily;
        }
    }
}
