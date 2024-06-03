
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Text;
using Color = Microsoft.Maui.Graphics.Color;
using Font = Microsoft.Maui.Graphics.Font;

namespace SIOT.Controls.Charts;

public class RadialBarChartDrawable : IDrawable
{
    private readonly RadialBarChart _chart;

    public RadialBarChartDrawable(RadialBarChart chart) => _chart = chart;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (_chart.Entries == null)
        {
            return;
        }

        var maxValue = _chart.MaxValue >= 0 ?
            _chart.MaxValue :
            _chart.Entries.Max(x => x.Value);

        var center = dirtyRect.Center;

        var spacing = (float)_chart.BarSpacing;
        var radius = (float)_chart.InnerRadius;
        var fontSize = (float)_chart.FontSize;
        var barThickness = (float)_chart.BarThickness;

        canvas.StrokeSize = barThickness;
        canvas.FontColor = _chart.TextColor;
        canvas.FontSize = fontSize;
        canvas.StrokeLineCap = _chart.RoundedCaps ? LineCap.Round : LineCap.Butt;

        var startingAngle = 90;
        var angleSpan = _chart.ShowLabels ? 270 : 360;
        var isFullCircle = angleSpan == 360;

        foreach (var entry in _chart.Entries.Reverse())
        {
            // Draw bar background
            canvas.StrokeColor =
                _chart.BarBackgroundColor ??
                ToBackgroundColor(entry.Color);

            if (isFullCircle)
            {
                canvas.DrawCircle(center.X, center.Y, radius);
            }
            else
            {
                DrawArc(canvas, center, radius, startingAngle, startingAngle - angleSpan);
            }

            // Draw bar
            canvas.StrokeColor = entry.Color;

            if (entry.Value == maxValue && isFullCircle)
            {
                canvas.DrawCircle(center.X, center.Y, radius);
            }
            else
            {
                DrawArc(canvas, center, radius, startingAngle, startingAngle - (float)(entry.Value * angleSpan / maxValue));
            }

            if (_chart.ShowLabels)
            {
                // Draw label
                DrawLabel(canvas, center, spacing, radius, fontSize, entry);
            }

            radius += spacing;
        }
    }

    private void DrawLabel(ICanvas canvas, PointF center, float spacing, float radius, float fontSize, ChartEntry entry)
    {
        string text = entry.Text;
        if (!string.IsNullOrEmpty(_chart.LabelFormat))
        {
            try
            {
                text = string.Format(_chart.LabelFormat, entry.Text, entry.Value);
            }
            catch (FormatException)
            {
            }
        }

        var textSize = canvas.GetStringSize(
            text,
            Font.Default,
            fontSize,
            HorizontalAlignment.Center,
            VerticalAlignment.Center);

        var textRect = new Rect(
            center.X - textSize.Width - spacing,
            center.Y - radius - textSize.Height / 2,
            Math.Ceiling(textSize.Width) + fontSize / 3f,
            Math.Ceiling(textSize.Height));

        canvas.DrawString(
            text,
            textRect,
            HorizontalAlignment.Center,
            VerticalAlignment.Center,
            TextFlow.OverflowBounds);
    }

    private static void DrawArc(ICanvas canvas, PointF center, float radius, float start, float end)
    {
        // Angle 0 is the right
        // Degrees go counter clockwise, meaning 90 is top
        canvas.DrawArc(
            center.X - radius,
            center.Y - radius,
            2 * radius,
            2 * radius,
            startAngle: start,
            endAngle: end,
            clockwise: true,
            closed: false);
    }

    private static Color ToBackgroundColor(Color color)
    {
        return new Color(color.Red, color.Green, color.Blue, color.Alpha * 0.1f);
    }
}
