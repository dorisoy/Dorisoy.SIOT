namespace SIOT.Controls;
public partial class RoundedCornerImage : Border
{

    public RoundedCornerImage()
    {
        InitializeComponent();
    }

    public static BindableProperty SourceProperty =
            BindableProperty.Create(
                nameof(Source),
                typeof(ImageSource),
                typeof(RoundedCornerImage),
                defaultValue: null
            );

    public ImageSource Source
    {
        get { return (ImageSource)GetValue(SourceProperty); }
        set { SetValue(SourceProperty, value); }
    }
}