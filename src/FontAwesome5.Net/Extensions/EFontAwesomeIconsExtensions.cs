using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FontAwesome5.Extensions
{
    public static class EFontAwesomeIconsExtensions
    {
        /// <summary>
        /// Creates a new System.Windows.Media.ImageSource of a specified FontAwesomeIcon and foreground System.Windows.Media.Brush.
        /// </summary>
        /// <param name="icon">The FontAwesome icon to be drawn.</param>
        /// <param name="foregroundBrush">The System.Windows.Media.Brush to be used as the foreground.</param>
        /// <param name="emSize">The font size in em.</param>
        /// <returns>A new System.Windows.Media.ImageSource</returns>
        public static ImageSource CreateImageSource(this EFontAwesomeIcon icon, Brush foregroundBrush, double emSize = 100)
        {
            return new DrawingImage(icon.CreateDrawing(foregroundBrush, emSize));
        }

        /// <summary>
        /// Creates a new System.Windows.Media.Drawing of a specified FontAwesomeIcon and foreground System.Windows.Media.Brush.
        /// </summary>
        /// <param name="icon">The FontAwesome icon to be drawn.</param>
        /// <param name="foregroundBrush">The System.Windows.Media.Brush to be used as the foreground.</param>
        /// <param name="emSize">The font size in em.</param>
        /// <returns>A new System.Windows.Media.Drawing</returns>
        public static Drawing CreateDrawing(this EFontAwesomeIcon icon, Brush foregroundBrush, double emSize = 100)
        {
            var visual = new DrawingVisual();
            using (var drawingContext = visual.RenderOpen())
            {
                drawingContext.DrawText(icon.CreateFormattedText(foregroundBrush, emSize), new Point(0, 0));
            }
            return visual.Drawing;
        }

        /// <summary>
        /// Creates a new System.Windows.Media.FormattedText of a specified FontAwesomeIcon and foreground System.Windows.Media.Brush.
        /// </summary>
        /// <param name="icon">The FontAwesome icon to be drawn.</param>
        /// <param name="foregroundBrush">The System.Windows.Media.Brush to be used as the foreground.</param>
        /// <param name="emSize">The font size in em.</param>
        /// <returns>A new System.Windows.Media.FormattedText</returns>
        public static FormattedText CreateFormattedText(this EFontAwesomeIcon icon, Brush foregroundBrush, double emSize = 100)
        {
            return new FormattedText(icon.GetUnicode(), CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                        icon.GetTypeFace(), emSize, foregroundBrush)
            {
                TextAlignment = TextAlignment.Center,
            };
        }

        /// <summary>
        /// Creates a new System.Windows.Media.FormattedText of a specified FontAwesomeIcon and foreground System.Windows.Media.Brush.
        /// </summary>
        /// <param name="icon">The FontAwesome icon to be drawn.</param>
        /// <param name="foregroundBrush">The System.Windows.Media.Brush to be used as the foreground.</param>
        /// <param name="emSize">The font size in em.</param>
        /// <param name="flowDirection">The flow direction of the font</param>
        /// <param name="textFormattingMode">The text formatting mode of the font</param>
        /// <param name="numberSubstitution">The number substitution of the font.</param>
        /// <param name="textAlignment">The text alignment of the font</param>
        /// <returns>A new System.Windows.Media.FormattedText</returns>
        public static FormattedText CreateFormattedText(this EFontAwesomeIcon icon, Brush foregroundBrush, double emSize,
            FlowDirection flowDirection,
            TextFormattingMode textFormattingMode, 
            NumberSubstitution numberSubstitution,
            TextAlignment textAlignment)
        {
            return new FormattedText(icon.GetUnicode(), CultureInfo.InvariantCulture, flowDirection,
                        icon.GetTypeFace(), emSize, foregroundBrush, numberSubstitution, textFormattingMode)
            { 
                TextAlignment = textAlignment,
            };
        }

        /// <summary>
        /// Creates a new System.Windows.Shapes.Path of a specified FontAwesomeIcon and foreground System.Windows.Media.Brush.
        /// </summary>
        /// <param name="icon">The FontAwesome icon to be drawn.</param>
        /// <param name="foregroundBrush">The System.Windows.Media.Brush to be used as the foreground.</param>
        /// <param name="emSize">The font size in em.</param>
        /// <returns>A new System.Windows.Shapes.Path</returns>
        public static Path CreatePath(this EFontAwesomeIcon icon, Brush foregroundBrush, double emSize = 100)
        {
            if (icon.GetSvg(out var strPath, out var width, out var height))
            {
                return new Path
                {
                    Data = Geometry.Parse(strPath),
                    Width = width,
                    Height = height,
                    Fill = foregroundBrush
                };
            }
            return null;
        }
    }
}
