using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

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
    public static FontFamily RegularFontFamilyResource = new FontFamily("ms-appx:///FontAwesome5.UWP/Fonts/Font Awesome 5 Free-Regular-400.otf#Font Awesome 5 Free");

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
    public static FontFamily SolidFontFamilyResource = new FontFamily("ms-appx:///FontAwesome5.UWP/Fonts/Font Awesome 5 Free-Solid-900.otf#Font Awesome 5 Free");

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
    public static FontFamily BrandsFontFamilyResource = new FontFamily("ms-appx:///FontAwesome5.UWP/Fonts/Font Awesome 5 Brands-Regular-400.otf#Font Awesome 5 Brands");

  }
}
