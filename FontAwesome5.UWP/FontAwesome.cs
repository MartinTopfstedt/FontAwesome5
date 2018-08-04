using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using FontAwesome5.UWP.Extensions;
using FontAwesome5.WPF.Extensions;

namespace FontAwesome5.UWP
{
    /// <summary>
    /// Represents ann icon that uses the FontAwesome font
    /// </summary>
    public class FontAwesome : FontIcon, ISpinable, IFlippable, IRotatable
    {
        static FontAwesome()
        {
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            nameof(Icon), typeof(EFontAwesomeIcon), typeof(FontAwesome), new PropertyMetadata(EFontAwesomeIcon.None, Icon_PropertyChangedCallback));

        /// <summary>
        /// Identifies the FontAwesome.WPF.FontAwesome.Spin dependency property.
        /// </summary>
        public static readonly DependencyProperty SpinProperty = DependencyProperty.Register(
            nameof(Spin), typeof(bool), typeof(FontAwesome), new PropertyMetadata(false, OnSpinPropertyChanged));

        /// <summary>
        /// Identifies the FontAwesome.WPF.FontAwesome.SpinDuration dependency property.
        /// </summary>
        public static readonly DependencyProperty SpinDurationProperty = DependencyProperty.Register(
            nameof(SpinDuration), typeof(double), typeof(FontAwesome), new PropertyMetadata(1d, SpinDurationChanged));

        /// <summary>
        /// Identifies the FontAwesome.WPF.FontAwesome.Rotation dependency property.
        /// </summary>
        public static readonly DependencyProperty RotationProperty = DependencyProperty.Register(
            nameof(Rotation), typeof(double), typeof(FontAwesome), new PropertyMetadata(0d, RotationChanged));

        /// <summary>
        /// Identifies the FontAwesome.WPF.FontAwesome.FlipOrientation dependency property.
        /// </summary>
        public static readonly DependencyProperty FlipOrientationProperty = DependencyProperty.Register(
            nameof(FlipOrientation), typeof(EFlipOrientation), typeof(FontAwesome), new PropertyMetadata(EFlipOrientation.Normal, FlipOrientationChanged));

        private static void Icon_PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var fontAwesome = (FontAwesome)dependencyObject;
            var newValue = (EFontAwesomeIcon)e.NewValue;

            var fontFamily = newValue.GetFontFamily();
            var glyph = newValue.GetUnicode();

            fontAwesome.SetValue(FontFamilyProperty, fontFamily);
            fontAwesome.SetValue(GlyphProperty, glyph);
        }

        /// <summary>
        /// Gets or sets the FontAwesome icon
        /// </summary>
        public EFontAwesomeIcon Icon
        {
            get => (EFontAwesomeIcon)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Gets or sets the current spin (angle) animation of the icon.
        /// </summary>
        public bool Spin
        {
            get => (bool)GetValue(SpinProperty);
            set => SetValue(SpinProperty, value);
        }

        private static void OnSpinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fontAwesome = d as FontAwesome;

            if (fontAwesome == null) return;

            if ((bool)e.NewValue)
                fontAwesome.BeginSpin();
            else
            {
                fontAwesome.StopSpin();
                fontAwesome.SetRotation();
            }
        }
        
        /// <summary>
        /// Gets or sets the duration of the spinning animation (in seconds). This will stop and start the spin animation.
        /// </summary>
        public double SpinDuration
        {
            get => (double)GetValue(SpinDurationProperty);
            set => SetValue(SpinDurationProperty, value);
        }

        private static void SpinDurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fontAwesome = d as FontAwesome;

            if (null == fontAwesome || !fontAwesome.Spin || !(e.NewValue is double) || e.NewValue.Equals(e.OldValue)) return;

            fontAwesome.StopSpin();
            fontAwesome.BeginSpin();
        }
        
        /// <summary>
        /// Gets or sets the current rotation (angle).
        /// </summary>
        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }

        private static void RotationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fontAwesome = d as FontAwesome;

            if (null == fontAwesome || fontAwesome.Spin || !(e.NewValue is double) || e.NewValue.Equals(e.OldValue)) return;

            fontAwesome.SetRotation();
        }
        
        /// <summary>
        /// Gets or sets the current orientation (horizontal, vertical).
        /// </summary>
        public EFlipOrientation FlipOrientation
        {
            get { return (EFlipOrientation)GetValue(FlipOrientationProperty); }
            set { SetValue(FlipOrientationProperty, value); }
        }

        private static void FlipOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fontAwesome = d as FontAwesome;

            if (null == fontAwesome || !(e.NewValue is EFlipOrientation) || e.NewValue.Equals(e.OldValue)) return;

            fontAwesome.SetFlipOrientation();
        }
    }
}