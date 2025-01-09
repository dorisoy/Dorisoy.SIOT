using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOT.Controls;

public class RadarDrawable : IDrawable
{
    public double MaxRadius { get; set; } = 150;
    public double[] CurrentRadius { get; private set; } = new double[5];
    public float[] Opacity { get; private set; } = new float[5];

    public RadarDrawable()
    {
        for (int i = 0; i < CurrentRadius.Length; i++)
        {
            CurrentRadius[i] = i * (MaxRadius / CurrentRadius.Length);
            Opacity[i] = 1 - (i * (1f / CurrentRadius.Length));
        }
    }

    /// <summary>
    /// 定义所需的图形绘制逻辑
    /// </summary>
    /// <param name="canvas"></param>
    /// <param name="dirtyRect"></param>
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();
        var center = new PointF((float)dirtyRect.Width / 2, (float)dirtyRect.Height / 2);
        for (int i = 0; i < CurrentRadius.Length; i++)
        {
            // 将透明度（Opacity）值乘以 255 得到一个 byte 型的透明度，并手动设置颜色
            byte alpha = (byte)(Opacity[i] * 255);

            // 设置颜色并绘制圆形 2566dc
            canvas.FillColor = Color.FromRgba(37, 102, 220, (int)alpha); // 白色，应用透明度;
            canvas.FillCircle(center, (float)CurrentRadius[i]);
        }

        canvas.RestoreState();
    }

    public void Update()
    {
        for (int i = 0; i < CurrentRadius.Length; i++)
        {
            CurrentRadius[i] += 2.5;
            Opacity[i] *= 0.92f;

            if (CurrentRadius[i] > MaxRadius)
            {
                CurrentRadius[i] = 0;
                Opacity[i] = 1;
            }
        }
    }
}
