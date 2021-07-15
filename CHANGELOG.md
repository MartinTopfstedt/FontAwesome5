# 2.1.4
 - Removed ResourceDictionary(FontAwesome5Dictionary.xaml)
 - Added new function for Font saving and loading to Fonts class.
   - fonts now get saved to temporary directory and referenced from there to prevent memory leak
# 2.1.3
- Added ImageSourceSvgConverter
- Made the Font Families adjustable on the static Fonts class
- Introduced a new ReosurceDictionary (FontAwesome5Dictionary.xaml) to prevent memory leaks
# 2.1.2
- Fixed issue #31
# 2.1.1
- Updated FontAwesome v5.15.3
- Updated UWP Min Target to: 10.0.10240.0
- Updated UWP Target to: 10.0.19041.0
# 2.0.0
- Added .Net Core 3.0 support
- Updated UWP Target Version to 17763
- Breaking Change: merged FontAwesome5.WPF namespace into FontAwesome5