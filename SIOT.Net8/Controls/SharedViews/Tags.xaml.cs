namespace SIOT.Controls;
public partial class Tag : ContentView
{
    public Tag()
    {
        InitializeComponent();
    }

    public static BindableProperty ImageProperty =
        BindableProperty.Create(
            nameof(Image),
            typeof(ImageSource),
            typeof(Tag),
            defaultValue: null
        );

    public ImageSource Image
    {
        get { return (ImageSource)GetValue(ImageProperty); }
        set { SetValue(ImageProperty, value); }
    }

    public static BindableProperty ImageSizeProperty =
        BindableProperty.Create(
            nameof(ImageSize),
            typeof(Double),
            typeof(Tag),
            defaultValue: 20.0
        );

    public Double ImageSize
    {
        get { return (Double)GetValue(ImageSizeProperty); }
        set { SetValue(ImageSizeProperty, value); }
    }

    public static BindableProperty TextColorProperty =
        BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(Tag),
            defaultValue: Color.FromArgb("#FFFFFF")
        );

    public Color TextColor
    {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }

    public static BindableProperty TextProperty =
        BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(Tag),
            defaultValue: ""
        );

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public static BindableProperty IconProperty =
        BindableProperty.Create(
            nameof(Icon),
            typeof(string),
            typeof(Tag),
            defaultValue: ""
        );

    public string Icon
    {
        get { return (string)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }

    public static BindableProperty CornerRadiusProperty =
        BindableProperty.Create(
            nameof(CornerRadius),
            typeof(Double),
            typeof(Tag),
            defaultValue: 6.0
        );

    public Double CornerRadius
    {
        get { return (Double)GetValue(CornerRadiusProperty); }
        set { SetValue(CornerRadiusProperty, value); }
    }

    public static BindableProperty FontSizeProperty =
        BindableProperty.Create(
            nameof(FontSize),
            typeof(Double),
            typeof(Tag),
            defaultValue: 10.0
        );

    public Double FontSize
    {
        get { return (Double)GetValue(FontSizeProperty); }
        set { SetValue(FontSizeProperty, value); }
    }

    public static BindableProperty IconFontSizeProperty =
        BindableProperty.Create(
            nameof(IconFontSize),
            typeof(Double),
            typeof(Tag),
            defaultValue: 10.0
        );

    public Double IconFontSize
    {
        get { return (Double)GetValue(IconFontSizeProperty); }
        set { SetValue(IconFontSizeProperty, value); }
    }

    public static BindableProperty FontAttributesProperty =
        BindableProperty.Create(
            nameof(FontAttributes),
            typeof(Enum),
            typeof(Tag),
            defaultValue: null
        );

    public Enum FontAttributes
    {
        get { return (Enum)GetValue(FontAttributesProperty); }
        set { SetValue(FontAttributesProperty, value); }
    }
}