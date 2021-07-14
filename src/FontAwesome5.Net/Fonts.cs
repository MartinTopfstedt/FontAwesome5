using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FontAwesome5
{
  /// <summary>
  /// Provides FontFamilies and Typefaces of FontAwesome5.
  /// </summary>
  public static class Fonts
  {
    /// <summary>
    /// FontAwesome5 Regular FontFamily
    /// </summary>
    public static FontFamily RegularFontFamily
    {
      set { _regularFontFamily = value; }
      get
      {
        if (_regularFontFamily != null)
        {
          return _regularFontFamily;
        }
        else if (Application.Current.Resources["FontAwesome5Regular"] is FontFamily resource)
        {
          return resource;
        }

        return RegularFontFamilyResource;
      }
    }
    private static FontFamily _regularFontFamily;
    public static FontFamily RegularFontFamilyResource = new FontFamily(new Uri("pack://application:,,,/FontAwesome5.Net;component/"), "./Fonts/#Font Awesome 5 Free Regular");

    /// <summary>
    /// FontAwesome5 Solid FontFamily
    /// </summary>
    public static FontFamily SolidFontFamily
    {
      set { _solidFontFamily = value; }
      get
      {
        if (_solidFontFamily != null)
        {
          return _solidFontFamily;
        }
        else if (Application.Current.Resources["FontAwesome5Solid"] is FontFamily resource)
        {
          return resource;
        }

        return SolidFontFamilyResource;
      }
    }
    private static FontFamily _solidFontFamily;
    public static FontFamily SolidFontFamilyResource = new FontFamily(new Uri("pack://application:,,,/FontAwesome5.Net;component/"), "./Fonts/#Font Awesome 5 Free Solid");

    /// <summary>
    /// FontAwesome5 Brands FontFamily
    /// </summary>
    public static FontFamily BrandsFontFamily
    {
      set { _brandsFontFamily = value; }
      get
      {
        if (_brandsFontFamily != null)
        {
          return _brandsFontFamily;
        }
        else if (Application.Current.Resources["FontAwesome5Brands"] is FontFamily resource)
        {
          return resource;
        }

        return BrandsFontFamilyResource;
      }
    }
    private static FontFamily _brandsFontFamily;
    public static FontFamily BrandsFontFamilyResource = new FontFamily(new Uri("pack://application:,,,/FontAwesome5.Net;component/"), "./Fonts/#Font Awesome 5 Brands Regular");

    /// <summary>
    /// FontAwesome5 Regular Typeface
    /// </summary>
    public static Typeface RegularTypeface => new Typeface(RegularFontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
    /// <summary>
    /// FontAwesome5 Solid Typeface
    /// </summary>
    public static Typeface SolidTypeface => new Typeface(SolidFontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
    /// <summary>
    /// FontAwesome5 Brands Typeface
    /// </summary>
    public static Typeface BrandsTypeface => new Typeface(BrandsFontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
  }
}
