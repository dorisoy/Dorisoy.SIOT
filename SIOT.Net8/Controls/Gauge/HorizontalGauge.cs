namespace SIOT.Controls
{
    internal class HorizontalGauge : GaugeBase
    {
        protected override void InternalDraw(ICanvas canvas, RectF dirtyRect)
        {
            int gaugeTotalLength = Convert.ToInt32(Width == 0 ? 330 : Width);
            canvas.StrokeLineCap = LineCap.Round;
            canvas.StrokeSize = 8;

            canvas.StrokeColor = BackgroundColor;
            canvas.DrawLine(0, 10, 0 + gaugeTotalLength, 10);

            double range = GaugeMaximum - GaugeMinimum;
            double length = (ConstrainedValue - GaugeMinimum) / range * gaugeTotalLength;

            canvas.StrokeColor = GaugeColor;
            canvas.DrawLine(0, 10, 0 + (float)length, 10);

            if (IsLabelShown)
            {
                canvas.FontColor = LabelColor;
                canvas.FontSize = 30;

                var format = $"{ConstrainedValue}{GaugeUnit}";

                canvas.DrawString(format, 0 + gaugeTotalLength, 0, HorizontalAlignment.Right);
            }
        }
    }
}
