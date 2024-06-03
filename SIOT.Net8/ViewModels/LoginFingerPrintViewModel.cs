namespace SIOT.ViewModels;

public partial class LoginFingerPrintViewModel : ObservableObject
{
    private readonly IBiometricAuthenticationService _authService;
    public LoginFingerPrintViewModel(IBiometricAuthenticationService authService) : base()
    {
        _authService = authService;
    }

    [RelayCommand]
    private async Task LoginAsync(CancellationToken cancellationToken)
    {
        var isBiometricAuthAvailable = await _authService.CheckIfBiometricsAreAvailableAsync();

        if (isBiometricAuthAvailable)
        {
            var authResult =
                await _authService.AuthenticateAsync("FaceID", "App requires FaceID in order to login");

            switch (authResult.Status)
            {
                case BiometricAuthenticationStatus.Success:
                    // handle success state
                    //await Shell.Current.GoToAsync("///MainView", true);
                    Application.Current.MainPage = MauiProgram.UsedAppShell switch
                    {
                        //AppShellType.Normal => new NormalAppShell(),
                        AppShellType.Sample => new SampleAppShell(),
                        _ => new MainAppShell()
                    };
                    break;
                case BiometricAuthenticationStatus.Failed:
                    // handle failed state
                    break;
                case BiometricAuthenticationStatus.Denied:
                    // handle denied state
                    break;
                case BiometricAuthenticationStatus.Unknown:
                case BiometricAuthenticationStatus.FallbackRequest:
                case BiometricAuthenticationStatus.Canceled:
                case BiometricAuthenticationStatus.TooManyAttempts:
                case BiometricAuthenticationStatus.NotAvailable:
                default:
                    // handle other states
                    break;
            }
        }
        else
        {
            // handle not available state
            await Shell.Current.GoToAsync("///LoginStyle1Page", true);
        }
    }

    [RelayCommand]
    private async Task SignupAsync()
    {

    }
}
