namespace SIOT.ViewModels;
public partial class AccountViewModel : ObservableObject
{
    public ICommand TapCommand { get; private set; }
    public string Name { get; set; } = "Alex Wilson";
    public string Email { get; set; } = "alex.wil@maui.com";
    public string ImageUrl { get; set; } = "150-13.jpg";

    public AccountViewModel()
    {

    }

    [RelayCommand]
    private  void UpdateAccount()
    {

    }

    [RelayCommand]
    private  void GotoPrivacy()
    {

    }

    [RelayCommand]
    private void Logout()
    {
        Application.Current.MainPage = new NavigationPage(new LoginStyle1Page());
    }
}
