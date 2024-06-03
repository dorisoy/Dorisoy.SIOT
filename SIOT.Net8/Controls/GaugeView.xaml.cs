namespace SIOT.Controls;

public partial class GaugeView : ContentView
{
    private readonly GraphicsView _graphicsView;
    private GaugeBase? GaugeDrawable => _graphicsView?.Drawable as GaugeBase;


    public static readonly BindableProperty GaugeTypeProperty =
        BindableProperty.Create(nameof(GaugeType), typeof(GaugeTypes), typeof(GaugeTypes), default(GaugeTypes), propertyChanged: OnGaugeTypeChanged);

    public GaugeTypes GaugeType
    {
        get { return (GaugeTypes)GetValue(GaugeTypeProperty); }
        set { SetValue(GaugeTypeProperty, value); }
    }

    public static readonly BindableProperty GaugeMinimumProperty =
           BindableProperty.Create(nameof(GaugeMinimum), typeof(double), typeof(double), default(double), propertyChanged: OnGaugeMinimumChanged);

    public double GaugeMinimum
    {
        get { return (double)GetValue(GaugeMinimumProperty); }
        set { SetValue(GaugeMinimumProperty, value); }
    }

    public static readonly BindableProperty GaugeMaximumProperty =
            BindableProperty.Create(nameof(GaugeMaximum), typeof(double), typeof(double), default(double), propertyChanged: OnGaugeMaximumChanged);

    public double GaugeMaximum
    {
        get { return (double)GetValue(GaugeMaximumProperty); }
        set { SetValue(GaugeMaximumProperty, value); }
    }

    public static readonly BindableProperty GaugeValueProperty =
        BindableProperty.Create(nameof(GaugeValue), typeof(double), typeof(double), default(double), propertyChanged: OnGaugeValueChanged);
    public double GaugeValue
    {
        get { return (double)GetValue(GaugeValueProperty); }
        set { SetValue(GaugeValueProperty, value); }
    }

    public static readonly BindableProperty GaugeColorProperty =
        BindableProperty.Create(nameof(GaugeColor), typeof(Color), typeof(Color), Microsoft.Maui.Graphics.Colors.Red, propertyChanged: OnGaugeColorChanged);

    public Color GaugeColor
    {
        get { return (Color)GetValue(GaugeColorProperty); }
        set { SetValue(GaugeColorProperty, value); }
    }

    public static readonly BindableProperty LabelColorProperty =
        BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(Color), Microsoft.Maui.Graphics.Colors.LightGrey, propertyChanged: OnLabelColorChanged);

    public Color LabelColor
    {
        get { return (Color)GetValue(LabelColorProperty); }
        set { SetValue(LabelColorProperty, value); }
    }

    public static readonly BindableProperty GaugeBackgroundColorProperty =
       BindableProperty.Create(nameof(GaugeBackgroundColor), typeof(Color), typeof(Color), Microsoft.Maui.Graphics.Colors.LightGrey, propertyChanged: OnBackgroundColorChanged);

    public Color GaugeBackgroundColor
    {
        get { return (Color)GetValue(GaugeBackgroundColorProperty); }
        set { SetValue(GaugeBackgroundColorProperty, value); }
    }

    public static readonly BindableProperty IsLabelShownProperty =
       BindableProperty.Create(nameof(IsLabelShown), typeof(bool), typeof(bool), true, propertyChanged: OnLabelShownChanged);

    public bool IsLabelShown
    {
        get { return (bool)GetValue(IsLabelShownProperty); }
        set { SetValue(IsLabelShownProperty, value); }
    }



    public static readonly BindableProperty GaugeUnitProperty =
    BindableProperty.Create(nameof(GaugeValue), typeof(string), typeof(string), default(string), propertyChanged: OnGaugeUnitChanged);
    public string GaugeUnit
    {
        get { return (string)GetValue(GaugeUnitProperty); }
        set { SetValue(GaugeUnitProperty, value); }
    }

    private static void OnGaugeUnitChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableUnit((string)newvalue);
    }




    public static readonly BindableProperty GaugeWidthProperty = BindableProperty.Create(nameof(GaugeWidth),
        typeof(double),
        typeof(double),
        default(double),
        propertyChanged: OnGaugeWidthChanged);
    public double GaugeWidth
    {
        get { return (double)GetValue(GaugeWidthProperty); }
        set { SetValue(GaugeWidthProperty, value); }
    }


    public static readonly BindableProperty GaugeHeightProperty = BindableProperty.Create(nameof(GaugeHeight),
    typeof(double),
    typeof(double),
    default(double),
    propertyChanged: OnGaugeHeightChanged);
    public double GaugeHeight
    {
        get { return (double)GetValue(GaugeHeightProperty); }
        set { SetValue(GaugeHeightProperty, value); }
    }



    private static void OnGaugeWidthChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableWidth((double)newvalue);
    }

    private static void OnGaugeHeightChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableHeight((double)newvalue);
    }



    public GaugeView()
    {
        InitializeComponent();

        _graphicsView = this.graphicsView;

        _graphicsView.WidthRequest = 220;
        _graphicsView.HeightRequest = 150;

        //_graphicsView.WidthRequest = Width;
        //_graphicsView.HeightRequest = Height;

        SetGaugeType(GaugeType);

        InnerInitialize();
    }


    private void InnerInitialize()
    {

        SetGaugeColor(GaugeColor);
        SetLabelColor(LabelColor);
        SetBackgroundColor(GaugeBackgroundColor);
        SetLabelShown(IsLabelShown);
        SetGaugeDrawableMaximum(GaugeMaximum);
        SetGaugeDrawableMinimum(GaugeMinimum);
    }

    private static void OnGaugeTypeChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
        {
            gaugeView.SetGaugeType((GaugeTypes)newvalue);
            gaugeView.InnerInitialize();
        }

    }

    private void SetGaugeType(GaugeTypes newType)
    {
        switch (newType)
        {
            case GaugeTypes.Curved:
                _graphicsView.Drawable = new CurvedGauge();
                break;
            case GaugeTypes.Horizontal:
                _graphicsView.Drawable = new HorizontalGauge();
                break;
            case GaugeTypes.HorizontalSymmetric:
                _graphicsView.Drawable = new HorizontalSymmetricGauge();
                break;
            default:
                throw new NotImplementedException($"No drawable is implemented for {newType}");
        }
    }

    private static void OnGaugeMinimumChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableMinimum((double)newvalue);
    }

    private void SetGaugeDrawableMinimum(double minimum)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.GaugeMinimum = minimum;

        _graphicsView.Invalidate();
    }

    private static void OnGaugeMaximumChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableMaximum((double)newvalue);
    }

    private void SetGaugeDrawableMaximum(double maximum)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.GaugeMaximum = maximum;
        _graphicsView.Invalidate();
    }

    private static void OnGaugeValueChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableValue((double)newvalue);
    }

    private void SetGaugeDrawableValue(double value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.GaugeValue = value;

        _graphicsView.Invalidate();
    }


    private void SetGaugeDrawableUnit(string unit)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.GaugeUnit = unit;

        _graphicsView.Invalidate();
    }


    private void SetGaugeDrawableWidth(double value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.Width = value;

        _graphicsView.WidthRequest = value;
        _graphicsView.Invalidate();
    }


    private void SetGaugeDrawableHeight(double value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.Height = value;

        _graphicsView.Invalidate();
    }

    private static void OnGaugeColorChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeColor((Color)newvalue);
    }

    private void SetGaugeColor(Color value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.GaugeColor = value;
        _graphicsView.Invalidate();
    }

    private static void OnLabelColorChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetLabelColor((Color)newvalue);
    }

    private void SetLabelColor(Color value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.LabelColor = value;
        _graphicsView.Invalidate();
    }

    private static void OnBackgroundColorChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetBackgroundColor((Color)newvalue);
    }

    private void SetBackgroundColor(Color value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.BackgroundColor = value;
        _graphicsView.Invalidate();
    }

    private static void OnLabelShownChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetLabelShown((bool)newvalue);
    }

    private void SetLabelShown(bool value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.IsLabelShown = value;
        _graphicsView.Invalidate();
    }
}