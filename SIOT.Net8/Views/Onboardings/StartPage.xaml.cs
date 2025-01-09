
namespace SIOT.Views.Onboardings;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }

    private async void TakeTour_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new WalkthroughImagePage());
        //await Shell.Current.GoToAsync(nameof(WalkthroughImagePage));
    }

    private async void Skip_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        //await Shell.Current.GoToAsync("..");
    }
}