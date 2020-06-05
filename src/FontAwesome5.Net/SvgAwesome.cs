using FontAwesome5.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FontAwesome5
{
    public class SvgAwesome : Viewbox, ISpinable, IRotatable, IFlippable, IPulsable
    {
        /// <summary>
        /// Identifies the FontAwesome.WPF.SvgAwesome.Foreground dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(SvgAwesome), new PropertyMetadata(Brushes.Black, OnIconPropertyChanged));
        /// <summary>
        /// Identifies the FontAwesome.WPF.SvgAwesome.Icon dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(EFontAwesomeIcon), typeof(SvgAwesome), new PropertyMetadata(EFontAwesomeIcon.None, OnIconPropertyChanged));
        /// <summary>
        /// Identifies the FontAwesome.WPF.SvgAwesome.Spin dependency property.
        /// </summary>
        public static readonly DependencyProperty SpinProperty =
            DependencyProperty.Register("Spin", typeof(bool), typeof(SvgAwesome), new PropertyMetadata(false, OnSpinPropertyChanged, SpinCoerceValue));
        /// <summary>
        /// Identifies the FontAwesome.WPF.SvgAwesome.Spin dependency property.
        /// </summary>
        public static readonly DependencyProperty SpinDurationProperty =
            DependencyProperty.Register("SpinDuration", typeof(double), typeof(SvgAwesome), new PropertyMetadata(1d, SpinDurationChanged, SpinDurationCoerceValue));
        /// <summary>
        /// Identifies the FontAwesome.WPF.FontAwesome.Pulse dependency property.
        /// </summary>
        public static readonly DependencyProperty PulseProperty =
            DependencyProperty.Register("Pulse", typeof(bool), typeof(SvgAwesome), new PropertyMetadata(false, OnPulsePropertyChanged, PulseCoerceValue));
        /// <summary>
        /// Identifies the FontAwesome.WPF.FontAwesome.PulseDuration dependency property.
        /// </summary>
        public static readonly DependencyProperty PulseDurationProperty =
            DependencyProperty.Register("PulseDuration", typeof(double), typeof(SvgAwesome), new PropertyMetadata(1d, PulseDurationChanged, PulseDurationCoerceValue));
        /// <summary>
        /// Identifies the FontAwesome.WPF.SvgAwesome.Rotation dependency property.
        /// </summary>
        public static readonly DependencyProperty RotationProperty =
            DependencyProperty.Register("Rotation", typeof(double), typeof(SvgAwesome), new PropertyMetadata(0d, RotationChanged, RotationCoerceValue));
        /// <summary>
        /// Identifies the FontAwesome.WPF.SvgAwesome.FlipOrientation dependency property.
        /// </summary>
        public static readonly DependencyProperty FlipOrientationProperty =
            DependencyProperty.Register("FlipOrientation", typeof(EFlipOrientation), typeof(SvgAwesome), new PropertyMetadata(EFlipOrientation.Normal, FlipOrientationChanged));
        
        static SvgAwesome()
        {
            OpacityProperty.OverrideMetadata(typeof(SvgAwesome), new UIPropertyMetadata(1.0, OpacityChanged));
        }

        public SvgAwesome()
        {
            IsVisibleChanged += (s, a) => CoerceValue(SpinProperty);
        }

        private static void OpacityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(SpinProperty);
        }

        /// <summary>
        /// Gets or sets the foreground brush of the icon. Changing this property will cause the icon to be redrawn.
        /// </summary>
        public Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets the FontAwesome icon. Changing this property will cause the icon to be redrawn.
        /// </summary>
        public EFontAwesomeIcon Icon
        {
            get { return (EFontAwesomeIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Gets or sets the current spin (angle) animation of the icon.
        /// </summary>
        public bool Spin
        {
            get { return (bool)GetValue(SpinProperty); }
            set { SetValue(SpinProperty, value); }
        }

        private static void OnSpinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var svgAwesome = d as SvgAwesome;

            if (svgAwesome == null) return;

            if ((bool)e.NewValue)
                svgAwesome.BeginSpin();
            else
            {
                svgAwesome.StopSpin();
                svgAwesome.SetRotation();
            }
        }

        private static object SpinCoerceValue(DependencyObject d, object basevalue)
        {
            var svgAwesome = (SvgAwesome)d;

            if (!svgAwesome.IsVisible || svgAwesome.Opacity == 0.0 || svgAwesome.SpinDuration == 0.0)
                return false;

            return basevalue;
        }

        /// <summary>
        /// Gets or sets the duration of the spinning animation (in seconds). This will stop and start the spin animation.
        /// </summary>
        public double SpinDuration
        {
            get { return (double)GetValue(SpinDurationProperty); }
            set { SetValue(SpinDurationProperty, value); }
        }

        private static void SpinDurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var svgAwesome = d as SvgAwesome;

            if (null == svgAwesome || !svgAwesome.Spin || !(e.NewValue is double) || e.NewValue.Equals(e.OldValue)) return;

            svgAwesome.StopSpin();
            svgAwesome.BeginSpin();
        }

        private static object SpinDurationCoerceValue(DependencyObject d, object value)
        {
            double val = (double)value;
            return val < 0 ? 0d : value;
        }

        /// <summary>
        /// Gets or sets the current pulse animation of the icon.
        /// </summary>
        public bool Pulse
        {
            get { return (bool)GetValue(PulseProperty); }
            set { SetValue(PulseProperty, value); }
        }

        private static void OnPulsePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fontAwesome = d as SvgAwesome;

            if (fontAwesome == null) return;

            if ((bool)e.NewValue)
                fontAwesome.BeginPulse();
            else
            {
                fontAwesome.StopPulse();
                fontAwesome.SetRotation();
            }
        }

        private static object PulseCoerceValue(DependencyObject d, object basevalue)
        {
            var fontAwesome = (SvgAwesome)d;

            if (!fontAwesome.IsVisible || fontAwesome.Opacity == 0.0 || fontAwesome.PulseDuration == 0.0)
                return false;

            return basevalue;
        }

        /// <summary>
        /// Gets or sets the duration of the pulse animation (in seconds). This will stop and start the pulse animation.
        /// </summary>
        public double PulseDuration
        {
            get { return (double)GetValue(PulseDurationProperty); }
            set { SetValue(PulseDurationProperty, value); }
        }

        private static void PulseDurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fontAwesome = d as SvgAwesome;

            if (null == fontAwesome || !fontAwesome.Pulse || !(e.NewValue is double) || e.NewValue.Equals(e.OldValue)) return;

            fontAwesome.StopPulse();
            fontAwesome.BeginPulse();
        }

        private static object PulseDurationCoerceValue(DependencyObject d, object value)
        {
            double val = (double)value;
            return val < 0 ? 0d : value;
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
            var svgAwesome = d as SvgAwesome;

            if (null == svgAwesome || svgAwesome.Spin || !(e.NewValue is double) || e.NewValue.Equals(e.OldValue)) return;

            svgAwesome.SetRotation();
        }

        private static object RotationCoerceValue(DependencyObject d, object value)
        {
            double val = (double)value;
            return val < 0 ? 0d : (val > 360 ? 360d : value);
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
            var svgAwesome = d as SvgAwesome;

            if (null == svgAwesome || !(e.NewValue is EFlipOrientation) || e.NewValue.Equals(e.OldValue)) return;

            svgAwesome.SetFlipOrientation();
        }

        private static void OnIconPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var svgAwesome = d as SvgAwesome;

            if (svgAwesome == null) return;

            if (svgAwesome.Icon == EFontAwesomeIcon.None)
            {
                svgAwesome.Child = null;
            }
            else
            {
                svgAwesome.Child = CreatePath(svgAwesome.Icon, svgAwesome.Foreground);
            }
        }

        /// <summary>
        /// Creates a new System.Windows.Media.ImageSource of a specified FontAwesomeIcon and foreground System.Windows.Media.Brush.
        /// </summary>
        /// <param name="icon">The FontAwesome icon to be drawn.</param>
        /// <param name="foregroundBrush">The System.Windows.Media.Brush to be used as the foreground.</param>
        /// <param name="emSize">The font size in em.</param>
        /// <returns>A new System.Windows.Media.ImageSource</returns>
        public static Path CreatePath(EFontAwesomeIcon icon, Brush foregroundBrush, double emSize = 100)
        {
            Path path = null;
            if (icon.GetSvg(out var strPath, out var width, out var height))
            {
                path = new Path();
                path.Data = Geometry.Parse(strPath);
                path.Width = width;
                path.Height = height;
                path.Fill = foregroundBrush;
            }
            return path;          
        }
    }
}
