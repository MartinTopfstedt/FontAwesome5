using System;
using System.Linq;
using System.Reflection;

namespace FontAwesome5.Extensions
{
    /// <summary>
    /// EFontAwesomeIcon extensions
    /// </summary>
    public static class EFontAwesomeIconExtensions
    {
        /// <summary>
        /// Get the Font Awesome information of an icon
        /// </summary>
        public static FontAwesomeInformation GetInformation(this EFontAwesomeIcon icon)
        {
            return FontAwesome.Information.TryGetValue(icon, out var info) ? info : null;
        }

        /// <summary>
        /// Get the Font Awesome label of an icon
        /// </summary>
        public static string GetLabel(this EFontAwesomeIcon icon)
        {
            return FontAwesome.Information.TryGetValue(icon, out var info) ? info.Label : null;
        }

        /// <summary>
        /// Get the Font Awesome Style of an icon
        /// </summary>
        public static EFontAwesomeStyle GetStyle(this EFontAwesomeIcon icon)
        {
            return FontAwesome.Information.TryGetValue(icon, out var info) ? info.Style : EFontAwesomeStyle.None;
        }

        /// <summary>
        /// Get the SVG path of an icon
        /// </summary>
        public static bool GetSvg(this EFontAwesomeIcon icon, out string path, out int width, out int height)
        {
            path = string.Empty;
            width = -1;
            height = -1;
            if (FontAwesome.Information.TryGetValue(icon, out var info) && info.Svg != null)
            {
                path = info.Svg.Path;
                width = info.Svg.Width;
                height = info.Svg.Height;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get the Unicode of an icon
        /// </summary>
        public static string GetUnicode(this EFontAwesomeIcon icon)
        {
            return FontAwesome.Information.TryGetValue(icon, out var info) ? info.Unicode : char.ConvertFromUtf32(0);
        }        
    }
}
