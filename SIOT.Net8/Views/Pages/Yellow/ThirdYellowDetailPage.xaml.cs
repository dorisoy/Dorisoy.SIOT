namespace SIOT.Views.Pages;

public partial class ThirdYellowDetailPage : ContentPage
{
    public ThirdYellowDetailPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(GreenPage)}", true);
    }
}