using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOT.Controls.Charts;

public class RadialBarChart : GraphicsView
{
    public RadialBarChart()
    {
        Drawable = new RadialBarChartDrawable(this);
    }

    public static readonly BindableProperty EntriesProperty =
        BindableProperty.Create(
            nameof(Entries),
            typeof(IEnumerable<ChartEntry>),
            typeof(RadialBarChart),
            defaultValue: null,
            propertyChanged: Invalidate);

    public IEnumerable<ChartEntry> Entries
    {
        get { return (IEnumerable<ChartEntry>)GetValue(EntriesProperty); }
        set { SetValue(EntriesProperty, value); }
    }

    public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create(
            nameof(MaxValue),
            typeof(double),
            typeof(RadialBarChart),
            defaultValue: -1d,
            propertyChanged: Invalidate);

    public double MaxValue
    {
        get { return (double)GetValue(MaxValueProperty); }
        set { SetValue(MaxValueProperty, value); }
    }

    public static readonly BindableProperty InnerRadiusProperty =
        BindableProperty.Create(
            nameof(InnerRadius),
            typeof(double),
            typeof(RadialBarChart),
            defaultValue: 50d,
            propertyChanged: Invalidate);

    public double InnerRadius
    {
        get { return (double)GetValue(InnerRadiusProperty); }
        set { SetValue(InnerRadiusProperty, value); }
    }

    public static readonly BindableProperty BarThicknessProperty =
        BindableProperty.Create(
            nameof(BarThickness),
            typeof(double),
            typeof(RadialBarChart),
            defaultValue: 10d,
            propertyChanged: Invalidate);

    public double BarThickness
    {
        get { return (double)GetValue(BarThicknessProperty); }
        set { SetValue(BarThicknessProperty, value); }
    }

    public static readonly BindableProperty BarSpacingProperty =
        BindableProperty.Create(
            nameof(BarSpacing),
            typeof(double),
            typeof(RadialBarChart),
            defaultValue: 20d,
            propertyChanged: Invalidate);

    public double BarSpacing
    {
        get { return (double)GetValue(BarSpacingProperty); }
        set { SetValue(BarSpacingProperty, value); }
    }

    public static readonly BindableProperty BarBackgroundColorProperty =
        BindableProperty.Create(
            nameof(BarBackgroundColor),
            typeof(Color),
            typeof(RadialBarChart),
            defaultValue: null,
            propertyChanged: Invalidate);

    public Color BarBackgroundColor
    {
        get { return (Color)GetValue(BarBackgroundColorProperty); }
        set { SetValue(BarBackgroundColorProperty, value); }
    }

    public static readonly BindableProperty RoundedCapsProperty =
        BindableProperty.Create(
            nameof(RoundedCaps),
            typeof(bool),
            typeof(RadialBarChart),
            defaultValue: true,
            propertyChanged: Invalidate);

    public bool RoundedCaps
    {
        get { return (bool)GetValue(RoundedCapsProperty); }
        set { SetValue(RoundedCapsProperty, value); }
    }

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(RadialBarChart),
            defaultValue: Color.FromArgb("#000000"),
            propertyChanged: Invalidate);

    public Color TextColor
    {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(
            nameof(FontSize),
            typeof(double),
            typeof(RadialBarChart),
            defaultValue: 12d,
            propertyChanged: Invalidate);

    public double FontSize
    {
        get { return (double)GetValue(FontSizeProperty); }
        set { SetValue(FontSizeProperty, value); }
    }

    public static readonly BindableProperty ShowLabelsProperty =
       BindableProperty.Create(
           nameof(ShowLabels),
           typeof(bool),
           typeof(RadialBarChart),
           defaultValue: false,
           propertyChanged: Invalidate);

    public bool ShowLabels
    {
        get { return (bool)GetValue(ShowLabelsProperty); }
        set { SetValue(ShowLabelsProperty, value); }
    }

    public static readonly BindableProperty LabelFormatProperty =
      BindableProperty.Create(
          nameof(LabelFormat),
          typeof(string),
          typeof(RadialBarChart),
          defaultValue: null,
          propertyChanged: Invalidate);

    public string LabelFormat
    {
        get { return (string)GetValue(LabelFormatProperty); }
        set { SetValue(LabelFormatProperty, value); }
    }

    private static void Invalidate(BindableObject bindable, object oldValue, object newValue) =>
        ((RadialBarChart)bindable).Invalidate();
}
