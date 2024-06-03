namespace SIOT.Controls;
public partial class AvatarWithStatus : ContentView
{

    public AvatarWithStatus()
    {
        InitializeComponent();
    }

    public static BindableProperty SourceProperty =
            BindableProperty.Create(
                nameof(Source),
                typeof(ImageSource),
                typeof(AvatarWithStatus),
                defaultValue: null
            );

    public ImageSource Source
    {
        get { return (ImageSource)GetValue(SourceProperty); }
        set { SetValue(SourceProperty, value); }
    }

    public static BindableProperty StatusProperty =
        BindableProperty.Create(
            nameof(Status),
            typeof(string),
            typeof(AvatarWithStatus),
            defaultValue: default(AvatarStatus).ToString()
        );

    public string Status
    {
        get { return (string)GetValue(StatusProperty); }
        set { SetValue(StatusProperty, value); }
    }

    public static BindableProperty AvatarHeightProperty =
            BindableProperty.Create(
                nameof(AvatarHeight),
                typeof(double),
                typeof(AvatarWithStatus),
                0.0,
                BindingMode.OneWay,
                validateValue: (_, value) => value != null);

    public double AvatarHeight
    {
        get { return (double)GetValue(AvatarHeightProperty); }
        set { SetValue(AvatarHeightProperty, value); }
    }

    public static BindableProperty AvatarWidthProperty =
            BindableProperty.Create(
                nameof(AvatarWidth),
                typeof(double),
                typeof(AvatarWithStatus),
                0.0,
                BindingMode.OneWay,
                validateValue: (_, value) => value != null);

    public double AvatarWidth
    {
        get { return (double)GetValue(AvatarWidthProperty); }
        set { SetValue(AvatarWidthProperty, value); }
    }

    // Convenience property
    public AvatarStatus StatusEnum
    {
        get
        {
            return Enum.TryParse(Status, out AvatarStatus result) ?
                result :
                default(AvatarStatus);
        }

        set { Status = value.ToString(); }
    }
}