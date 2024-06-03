namespace SIOT.Controls;

public partial class ImagePreviewPage : ContentPage
{
    public ImagePreviewPage(ImageSource source)
    {
        InitializeComponent();
        img.Source = source;
    }

    private async void OnImagePreviewDoubleTapped(object sender, EventArgs args)
    {
        const uint AnimationDuration = 100;

        if ((int)img.Scale == 1)
        {
            await img.ScaleTo(2, AnimationDuration, Easing.SinInOut);
        }
        else
        {
            await img.ScaleTo(1, AnimationDuration, Easing.SinInOut);
        }
    }

    private async void OnCloseButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PopModalAsync();
    }
}