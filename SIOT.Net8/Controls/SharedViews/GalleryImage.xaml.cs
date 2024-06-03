namespace SIOT.Controls;

public partial class GalleryImage : Border
{
    public GalleryImage()
    {
        InitializeComponent();
    }

    public static BindableProperty ImageProperty =
            BindableProperty.Create(
                nameof(Image),
                typeof(ImageSource),
                typeof(GalleryImage),
                null
            );

    public ImageSource Image
    {
        get { return (ImageSource)GetValue(ImageProperty); }
        set { SetValue(ImageProperty, value); }
    }

    private async void OnImageTapped(object sender, EventArgs e)
    {
#if !NAVIGATION
        var selectedItem = (GalleryImage)sender;
        var socialGalleryImagePreview = new ImagePreviewPage(selectedItem.Image);

        await Navigation.PushModalAsync(new NavigationPage(socialGalleryImagePreview));
#endif
    }
}