namespace SIOT.Controls;


/// <summary>
/// �Զ���RadialGauge
/// </summary>
public partial class RadialGauge : GraphicsView, IDrawable
{
    // IDrawable�ӿڵ�ʵ��
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // ��ȡ�ؼ������ĵ�
        // Get the center point of the control
        float centerX = dirtyRect.Width / 2;
        float centerY = dirtyRect.Height / 2;

        // ����ָ��ĽǶ�
        // Calculate the angle of the needle
        float valuePercentage = (_animatedValue - MinValue) / (MaxValue - MinValue);
        float needleAngle = CalculateAngle(valuePercentage);

        // ������̵İ뾶
        // Calculate the radius of the gauge
        float radius = Math.Min(centerX, centerY) - 10 - GaugeArcThickness;  // ��10Ϊ����һЩ�߾� // Subtract 10 to leave some margin

        // ���Ʊ��̱��������
        // Draw the gauge background and fill
        var arcX = centerX - radius;
        var arcY = centerY - radius;
        var arcRect = new RectF(arcX, arcY, radius * 2, radius * 2);
        var gaugeStartAngle = ArcAngle(StartAngle);
        var gaugeBackgroundStopAngle = ArcAngle(StartAngle + SweepAngle);
        var gaugeFillStopAngle = ArcAngle(needleAngle);

        canvas.StrokeLineCap = LineCap.Round;
        canvas.StrokeSize = GaugeArcThickness;
        canvas.StrokeColor = GaugeBackgroundColor;
        canvas.DrawArc(arcRect, gaugeStartAngle, gaugeBackgroundStopAngle, true, false);
        canvas.StrokeColor = _animatedValue >= AlertValue ? AlertFillColor : GaugeFillColor;
        canvas.DrawArc(arcRect, gaugeStartAngle, gaugeFillStopAngle, true, false);

        // ����ָ����յ����꣬ʹ�� NeedleLength ���Ե�������
        // Calculate the end point of the needle, use the NeedleLength property to adjust the length
        var needleEnd = CalculatePoint(centerX, centerY, radius * NeedleLength, needleAngle);

        // ����ָ��
        // Draw the needle
        canvas.StrokeColor = NeedleColor;
        canvas.StrokeSize = NeedleThickness;
        canvas.DrawLine(centerX, centerY, (float)needleEnd.X, (float)needleEnd.Y);

        // ����̶ȵ�����
        // Calculate the number of ticks
        int tickCount = (int)((MaxValue - MinValue) / TickInterval) + 1;

        // ���ƿ̶�
        // Draw the ticks
        for (int i = 0; i < tickCount; i++)
        {
            float tickValue = MinValue + (i * TickInterval);
            float tickPercentage = (tickValue - MinValue) / (MaxValue - MinValue);
            float tickAngle = CalculateAngle(tickPercentage);

            // ����̶ȵ������յ�����
            // Calculate the start and end points of the tick
            var tickStart = CalculatePoint(centerX, centerY, radius - TickLength - GaugeArcThickness, tickAngle);
            var tickEnd = CalculatePoint(centerX, centerY, radius - GaugeArcThickness, tickAngle);

            // ���ƿ̶���
            // Draw the tick line
            canvas.StrokeColor = Microsoft.Maui.Graphics.Colors.Gray;
            canvas.StrokeSize = 1;
            canvas.DrawLine(tickStart.X, tickStart.Y, tickEnd.X, tickEnd.Y);
        }

        float labelY = centerY + (radius * MathF.Sin(StartAngle * MathF.PI / 180)) + LabelFontSize + GaugeArcThickness;
        canvas.FontSize = LabelFontSize;

        // ������Сֵ��ǩ
        // Draw the minimum value label
        float minLabelX = centerX + (radius * MathF.Cos(StartAngle * MathF.PI / 180));
        canvas.DrawString(MinValue.ToString(), minLabelX, labelY, HorizontalAlignment.Center);

        // �������ֵ��ǩ
        // Draw the maximum value label
        float maxLabelX = centerX + (radius * MathF.Cos((StartAngle + SweepAngle) * MathF.PI / 180));
        canvas.DrawString(MaxValue.ToString(), maxLabelX, labelY, HorizontalAlignment.Center);

        // ���Ƶ�ǰֵ��ǩ
        // Draw the current value label
        canvas.FontSize = LabelFontSize;
        float valueLabelX = centerX;
        float valueLabelY = centerY + LabelFontSize + 30;
        canvas.DrawString(_animatedValue.ToString(ValueLableFormat), valueLabelX, valueLabelY, HorizontalAlignment.Center);

        // ���Ƶ�λ��ǩ
        // Draw the units label
        float unitsLabelY = valueLabelY + LabelFontSize + 8;
        canvas.DrawString(Unit, valueLabelX, unitsLabelY, HorizontalAlignment.Center);

    }

    private float CalculateAngle(float percentage)
    {
        return StartAngle + (SweepAngle * percentage);
    }

    private PointF CalculatePoint(float centerX, float centerY, float radius, float angle)
    {
        float x = centerX + (radius * MathF.Cos(angle * MathF.PI / 180));
        float y = centerY + (radius * MathF.Sin(angle * MathF.PI / 180));
        return new PointF(x, y);
    }

    private float ArcAngle(float angle)
    {
        float normalizedAngle = ((angle % 360) + 360) % 360;
        if (normalizedAngle < 180)
            return -normalizedAngle;
        else
            return 360 - normalizedAngle;
    }

    public void AnimateTo(float value)
    {
        _targetValue = value;
        _animationTimer.Start();
    }

    private void OnAnimationTick(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (Math.Abs(_animatedValue - _targetValue) < 0.1)
        {
            _animationTimer.Stop();
            _animatedValue = _targetValue;
        }
        else
        {
            float step = (_targetValue - _animatedValue) * 0.1f;  // �򵥵����Բ�ֵ // Simple linear interpolation
            _animatedValue += step;
        }



        Invalidate();  // �����ػ�ؼ� // Request a redraw of the control
    }

    public RadialGauge()
    {
        Drawable = this;
        _animationTimer = new System.Timers.Timer(16);  // ���ö���֡��Ϊ60fps // Set the animation frame rate to 60fps
        this.Loaded += RadialGauge_Loaded;


    }

    private void RadialGauge_Loaded(object sender, EventArgs e)
    {

        _animationTimer.Elapsed += OnAnimationTick;
    }

    private float _animatedValue;
    private float _targetValue;
    private System.Timers.Timer _animationTimer;
}
