
namespace SIOT.Views.Onboardings;

public partial class DemoStartPage : ContentPage
{
    public DemoStartPage()
    {
        InitializeComponent();
    }

    private async void TakeTour_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DemoWalkthroughPage());
    }

    private async void Skip_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginStyle1Page());
    }
}