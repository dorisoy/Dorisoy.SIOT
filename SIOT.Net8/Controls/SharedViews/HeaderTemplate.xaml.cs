namespace SIOT.Controls;

public partial class HeaderTemplate : ContentView
{
    public HeaderTemplate()
    {
        InitializeComponent();
    }

    /* TEXT */
    public static BindableProperty TextProperty =
            BindableProperty.Create(
                nameof(Text),
                typeof(string),
                typeof(HeaderTemplate),
                string.Empty,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (HeaderTemplate)bindable;
                    ctrl.HeaderLabel.Text = (string)newValue;
                }
            );

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    /* TEXT SIZE */
    public static readonly BindableProperty TextSizeProperty = BindableProperty.Create(
        "TextSize",
        typeof(double),
        typeof(HeaderTemplate),
        0.0,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var ctrl = (HeaderTemplate)bindable;
            ctrl.HeaderLabel.FontSize = (double)newValue;
        });

    public double TextSize
    {
        get { return (double)GetValue(TextSizeProperty); }
        set { SetValue(TextSizeProperty, value); }
    }

    /* ICON */
    public static BindableProperty IconTextProperty =
        BindableProperty.Create(
            nameof(IconText),
            typeof(string),
            typeof(HeaderTemplate),
            string.Empty,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var ctrl = (HeaderTemplate)bindable;
                ctrl.HeaderIcon.Text = (string)newValue;
            }
        );

    public string IconText
    {
        get { return (string)GetValue(IconTextProperty); }
        set { SetValue(IconTextProperty, value); }
    }

    /* ICON FONT FAMILY */
    public static BindableProperty IconFontFamilyProperty =
        BindableProperty.Create(
            nameof(IconFontFamily),
            typeof(string),
            typeof(HeaderTemplate),
            string.Empty,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var ctrl = (HeaderTemplate)bindable;
                ctrl.HeaderIcon.FontFamily = (string)newValue;
            }
        );

    public string IconFontFamily
    {
        get { return (string)GetValue(IconFontFamilyProperty); }
        set { SetValue(IconFontFamilyProperty, value); }
    }

    /* ICON SIZE */
    public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(
        "IconSize",
        typeof(double),
        typeof(HeaderTemplate),
        0.0,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var ctrl = (HeaderTemplate)bindable;
            ctrl.HeaderIcon.FontSize = (double)newValue;
        });

    public double IconSize
    {
        get { return (double)GetValue(IconSizeProperty); }
        set { SetValue(IconSizeProperty, value); }
    }

    /* ICON COLOR */
    public static readonly BindableProperty IconColorProperty = BindableProperty.Create(
        "IconColor",
        typeof(Color),
        typeof(HeaderTemplate),
        Color.FromArgb("#6E6E6E"),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var ctrl = (HeaderTemplate)bindable;
            ctrl.HeaderIcon.TextColor = (Color)newValue;
        });

    public Color IconColor
    {
        get { return (Color)GetValue(IconColorProperty); }
        set { SetValue(IconColorProperty, value); }
    }
}