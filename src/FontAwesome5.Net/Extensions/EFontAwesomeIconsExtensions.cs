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
    /// Creates a new System.Windows.Media.ImageSource of a specified FontAwesomeIcon and foreground System.Windows.Media.Brush.
    /// </summary>
    /// <param name="icon">The FontAwesome icon to be drawn.</param>
    /// <param name="foregroundBrush">The System.Windows.Media.Brush to be used as the foreground.</param>    
    /// <returns>A new System.Windows.Media.ImageSource</returns>
    public static ImageSource CreateImageSource(this EFontAwesomeIcon icon, Brush foregroundBrush, Pen pen)
    {
      return new DrawingImage(icon.CreateDrawing(foregroundBrush, pen));
    }

    /// <summary>
    /// Creates a new System.Windows.Media.Drawing of a specified FontAwesomeIcon and foreground System.Windows.Media.Brush.
    /// This will use the Font for the Drawing creation.
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
    /// Creates a new System.Windows.Media.Drawing of a specified FontAwesomeIcon.
    /// This will use the SVG for the Drawing creation.
    /// </summary>
    /// <param name="icon">The FontAwesome icon to be drawn.</param>
    /// <param name="brush">The Brush with which to fill the Geometry. This is optional, and can be null. If the brush is null, no fill is drawn.</param>
    /// <param name="pen">The Pen with which to stroke the Geometry. This is optional, and can be null. If the pen is null, no stroke is drawn.</param>
    /// <returns>A new System.Windows.Media.Drawing</returns>
    public static Drawing CreateDrawing(this EFontAwesomeIcon icon, Brush brush, Pen pen)
    {
      var visual = new DrawingVisual();
      using (var drawingContext = visual.RenderOpen())
      {
        if (icon.GetSvg(out var strPath, out var width, out var height))
        {
          drawingContext.DrawGeometry(brush, pen, Geometry.Parse(strPath));
        }
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
    /// <returns>A new System.Windows.Media.FormattedText</returns>
    public static FormattedText CreateFormattedText(this EFontAwesomeIcon icon, Brush foregroundBrush, double emSize,
        FlowDirection flowDirection,
        TextFormattingMode textFormattingMode,
        NumberSubstitution numberSubstitution)
    {
      return new FormattedText(icon.GetUnicode(), CultureInfo.InvariantCulture, flowDirection,
                  icon.GetTypeFace(), emSize, foregroundBrush, numberSubstitution, textFormattingMode);
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

    /// <summary>
    /// Creates a new System.Windows.Media.Geometry of a specified FontAwesomeIcon.
    /// </summary>
    /// <param name="icon">The FontAwesome icon to be drawn.</param>
    /// <param name="width">The width of the SVG.</param>
    /// <param name="height">The height of the SVG</param>
    /// <returns>A new System.Windows.Media.Geometry</returns>
    public static Geometry CreateGeometry(this EFontAwesomeIcon icon, out int width, out int height)
    {
      if (icon.GetSvg(out var strPath, out width, out height))
      {
        return Geometry.Parse(strPath);
      }
      return null;
    }
  }
}
