using SkiaSharp;
using SkiaSharp.Extended;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace SIOT.Controls
{
    public class SpeedometerView : SKCanvasView
    {
        /// <summary>
        /// 定义 Speed 为绑定属性，使其可用于 XAML
        /// </summary>
        public static readonly BindableProperty MaxSpeedProperty = BindableProperty.Create(
            nameof(MaxSpeed),
            typeof(int),
            typeof(SpeedometerView),
            20000, // 默认值
            propertyChanged: OnMaxSpeedPropertyChanged);

        /// <summary>
        /// 定义最大速度180
        /// </summary>
        //private const int MaxSpeed = 180;
        public int MaxSpeed
        {
            get => (int)GetValue(MaxSpeedProperty);
            set => SetValue(MaxSpeedProperty, value);
        }

        private static void OnMaxSpeedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // 当 Speed 发生改变时，重绘 SpeedometerView
            ((SpeedometerView)bindable).InvalidateSurface();
        }

        /// <summary>
        ///  每个主刻度表示18的速度（0-180=10个主刻度）
        /// </summary>
        private const int MajorTickInterval = 18;

        /// <summary>
        /// 每个主要间隔9个小刻度
        /// </summary>
        private const int MinorTicksPerMajorTick = 9;

        /// <summary>
        /// 指针等腰三角形的底部宽度
        /// </summary>
        private const float NeedleWidth = 20f;

        /// <summary>
        /// 定义 Speed 为绑定属性，使其可用于 XAML
        /// </summary>
        public static readonly BindableProperty SpeedProperty = BindableProperty.Create(
            nameof(Speed),
            typeof(float),
            typeof(SpeedometerView),
            0f, // 默认值
            propertyChanged: OnSpeedPropertyChanged);

        public float Speed
        {
            get => (float)GetValue(SpeedProperty);
            set => SetValue(SpeedProperty, value);
        }

        /// <summary>
        /// Speed 属性发生变化时的事件处理
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnSpeedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // 当 Speed 发生改变时，重绘 SpeedometerView
            ((SpeedometerView)bindable).InvalidateSurface();
        }

        public SpeedometerView()
        {
            PaintSurface += OnCanvasViewPaintSurface;
        }

        private void OnCanvasViewPaintSurface(object? sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            var width = info.Width;
            var height = info.Height;
            var minDimension = Math.Min(width, height);

            // 设置画布的中心
            var centerX = width / 2;
            var centerY = height / 2;

            // 计算仪表盘的外半径
            var outerRadius = minDimension / 2.5f;

            // 绘制渐变弧线
            DrawGradientArc(canvas, centerX, centerY, outerRadius + 20, Speed);

            // 绘制刻度和标签
            DrawTicksAndLabels(canvas, centerX, centerY, outerRadius);

            // 绘制指针
            DrawNeedle(canvas, centerX, centerY, outerRadius - 40, Speed);
        }

        /// <summary>
        /// 绘制渐变弧线
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="radius"></param>
        /// <param name="speed"></param>
        private void DrawGradientArc(SKCanvas canvas, float centerX, float centerY, float radius, float speed)
        {
            // 渐变弧末端的速度到角度的转换角度将相对于135度的起点
            float endAngleDegrees = 135f + (speed / MaxSpeed) * 270f;

            using (var paint = new SKPaint())
            {
                // 设置绘制圆弧的笔划
                paint.Style = SKPaintStyle.Stroke;
                //圆角
                paint.StrokeCap = SKStrokeCap.Round;
                paint.StrokeWidth = 25;
                paint.IsAntialias = true;

                // 使用扫掠渐变创建渐变着色器
                // var colors = new SKColor[] { SKColors.Transparent, SKColors.Red  };
                var colors = new SKColor[] { SKColor.Parse("#2566dc"), SKColor.Parse("#2566dc") };
                var shader = SKShader.CreateSweepGradient(
                    new SKPoint(centerX, centerY),
                    colors,
                    [0, (speed / MaxSpeed)]
                );
                paint.Shader = shader;

                // 创建圆弧的矩形边界
                SKRect arcBounds = new SKRect(
                    centerX - radius,
                    centerY - radius,
                    centerX + radius,
                    centerY + radius);

                // 使用着色器从开始角度到结束角度绘制弧
                float startAngle = 135f; // 渐变弧的起始角度（与0速度标记对齐）
                float sweepAngle = endAngleDegrees - startAngle;

                canvas.DrawArc(arcBounds, startAngle, sweepAngle, false, paint);
            }
        }


        /// <summary>
        /// 绘制刻度和标签
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="radius"></param>
        private void DrawTicksAndLabels(SKCanvas canvas, float centerX, float centerY, float radius)
        {
            //总刻度
            var totalTicks = (MajorTickInterval * (MinorTicksPerMajorTick + 1));
            for (int i = 0; i <= totalTicks; i++)
            {
                bool isMajorTick = i % (10) == 0;
                float tickRadiusStart = isMajorTick ? radius - 40 : radius - 20;
                float tickRadiusEnd = radius;
                float angleDegrees = 135 + (270 * ((float)i / totalTicks));

                // 绘制刻度
                DrawTick(canvas, centerX, centerY, tickRadiusStart, tickRadiusEnd, angleDegrees, isMajorTick);

                // 绘制主刻度标签
                if (isMajorTick)
                {
                    float labelRadius = radius - 70;
                    var speed = Math.Round(i * 111.11);// ; //((i / (10)) * MajorTickInterval) / 180 * 10;
                    DrawLabel(canvas, centerX, centerY, labelRadius, angleDegrees, speed.ToString());
                }
            }
        }


        /// <summary>
        /// 绘制指针
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="needleLength"></param>
        /// <param name="speed"></param>
        private void DrawNeedle(SKCanvas canvas, float centerX, float centerY, float needleLength, float speed)
        {
            // 将速度转换为角度
            float angleDegrees = 135f + (speed / MaxSpeed) * 270f;
            // 将度数转换为弧度
            float angleRadians = angleDegrees * (float)Math.PI / 180f;

            // 计算针头的末端（尖端）点
            var tipX = centerX + needleLength * (float)Math.Cos(angleRadians);
            var tipY = centerY + needleLength * (float)Math.Sin(angleRadians);

            // 计算针三角形的两个基点
            float baseAngleOffset = (float)Math.PI / 2; // 底座偏移90度
            var baseOneX = centerX + NeedleWidth / 2 * (float)Math.Cos(angleRadians - baseAngleOffset);
            var baseOneY = centerY + NeedleWidth / 2 * (float)Math.Sin(angleRadians - baseAngleOffset);
            var baseTwoX = centerX + NeedleWidth / 2 * (float)Math.Cos(angleRadians + baseAngleOffset);
            var baseTwoY = centerY + NeedleWidth / 2 * (float)Math.Sin(angleRadians + baseAngleOffset);

            using (var needlePaint = new SKPaint())
            {
                needlePaint.IsAntialias = true;
                // 绘制指针.使用 SKPath 绘制闭合的三角形
                using (var needlePath = new SKPath())
                {
                    // 三角形的顶点
                    needlePath.MoveTo(tipX, tipY);
                    // 三角形的底部一个端点
                    needlePath.LineTo(baseOneX, baseOneY);
                    // 三角形的底部另一个端点
                    needlePath.LineTo(baseTwoX, baseTwoY);
                    // 闭合路径形成三角形
                    needlePath.Close();
                    needlePaint.Style = SKPaintStyle.Fill;
                    needlePaint.Color = SKColor.Parse("#2566dc");
                    // 填充路径绘制三角形
                    canvas.DrawPath(needlePath, needlePaint);
                }


                // 绘制指针底部固定的圆
                // 圆的半径，可根据实际需要调整
                float circleRadius = NeedleWidth + 10;
                needlePaint.Style = SKPaintStyle.Fill;
                needlePaint.Color = SKColor.Parse("#2566dc");
                canvas.DrawCircle(centerX, centerY, circleRadius, needlePaint);
            }
        }


        /// <summary>
        ///  绘制刻度
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="innerRadius"></param>
        /// <param name="outerRadius"></param>
        /// <param name="angleDegrees"></param>
        /// <param name="isMajorTick"></param>
        private void DrawTick(SKCanvas canvas, float centerX, float centerY, float innerRadius, float outerRadius, float angleDegrees, bool isMajorTick)
        {
            // Convert degrees to radians
            float angleRadians = angleDegrees * (float)Math.PI / 180f;

            float startX = centerX + innerRadius * (float)Math.Cos(angleRadians);
            float startY = centerY + innerRadius * (float)Math.Sin(angleRadians);
            float endX = centerX + outerRadius * (float)Math.Cos(angleRadians);
            float endY = centerY + outerRadius * (float)Math.Sin(angleRadians);

            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;
                paint.Color = isMajorTick ? SKColors.Gray : SKColors.Gray;
                paint.StrokeWidth = isMajorTick ? 3 : 1;
                canvas.DrawLine(startX, startY, endX, endY, paint);
            }
        }

        /// <summary>
        ///  绘制标签
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="radius"></param>
        /// <param name="angleDegrees"></param>
        /// <param name="label"></param>
        private void DrawLabel(SKCanvas canvas, float centerX, float centerY, float radius, float angleDegrees, string label)
        {
            // Convert degrees to radians
            float angleRadians = angleDegrees * (float)Math.PI / 180f;

            // Label position
            float x = centerX + radius * (float)Math.Cos(angleRadians);
            float y = centerY + radius * (float)Math.Sin(angleRadians);

            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;
                paint.Color = SKColor.Parse("#2566dc");
                paint.TextSize = 20;
                paint.TextAlign = SKTextAlign.Center;

                // Determine metrics for text vertical alignment
                var metrics = paint.FontMetrics;
                float textHeight = metrics.Descent - metrics.Ascent;
                float textOffset = textHeight / 2 - metrics.Descent;

                canvas.DrawText(label, x, y + textOffset, paint);
            }
        }
    }
}
