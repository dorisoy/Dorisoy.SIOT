namespace SIOT.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    public LoginViewModel()
    {

    }

    [RelayCommand]
    private void Login()
    {
        Application.Current.MainPage = MauiProgram.UsedAppShell switch
        {
            _ => new MainAppShell()
        };
    }

    [RelayCommand]
    private void ForgotPassword()
    {

    }
}
