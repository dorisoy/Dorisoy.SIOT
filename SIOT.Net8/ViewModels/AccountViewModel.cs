namespace SIOT.ViewModels;
public partial class AccountViewModel : ObservableObject
{
    public ICommand TapCommand { get; private set; }
    public string Name { get; set; } = "Alex Wilson";
    public string Email { get; set; } = "alex.wil@maui.com";
    public string ImageUrl { get; set; } = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/150-13.jpg";

    public AccountViewModel()
    {

    }

    [RelayCommand]
    private async void UpdateAccount()
    {
        await PopupAction.DisplayPopup(new AccountUpdatePage());
    }

    [RelayCommand]
    private async void GotoPrivacy()
    {
        await Shell.Current.GoToAsync(nameof(PrivacyPolicyPage));
    }

    [RelayCommand]
    private void Logout()
    {
        Application.Current.MainPage = new NavigationPage(new LoginStyle1Page());
    }
}
