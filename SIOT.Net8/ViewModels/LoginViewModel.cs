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
            //AppShellType.Normal => new NormalAppShell(),
            AppShellType.Sample => new SampleAppShell(),
            _ => new MainAppShell()
        };
    }

    [RelayCommand]
    private void ForgotPassword()
    {

    }
}
