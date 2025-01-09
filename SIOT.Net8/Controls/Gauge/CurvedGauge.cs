namespace SIOT.Controls
{
    internal class CurvedGauge : GaugeBase
    {
        protected override void InternalDraw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeLineCap = LineCap.Round;
            canvas.StrokeSize = 10;

            canvas.StrokeColor = BackgroundColor;
            canvas.DrawArc(10, 10, 200, 200, 0, 180, false, false);

            double range = GaugeMaximum - GaugeMinimum;
            double angle = (ConstrainedValue - GaugeMinimum) / range * 180;

            canvas.StrokeColor = GaugeColor;
            canvas.DrawArc(10, 10, 200, 200, 180 - (float)angle, 180, false, false);

            if (IsLabelShown)
            {
                canvas.FontColor = LabelColor;
                canvas.FontSize = 36;

                var format = $"{ConstrainedValue} {GaugeUnit}";

                canvas.DrawString(format, 110, 100, HorizontalAlignment.Center);
            }
        }
    }
}
