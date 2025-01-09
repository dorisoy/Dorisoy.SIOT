namespace SIOT.Views;

public partial class LoginStyle1Page : ContentPage
{
    public LoginStyle1Page()
    {
        InitializeComponent();
    }

    private async void GoBack_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new DemoStartPage());
    }

    private void SigninButton_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainAppShell();
    }

    private async void ForgotPassword_Tapped(object sender, TappedEventArgs e)
    {
        //await Navigation.PushAsync(new ForgotPasswordPage());
    }

    private async void Signup_Tapped(object sender, TappedEventArgs e)
    {
        //await Navigation.PushAsync(new SignUpStyle1Page());
    }
}