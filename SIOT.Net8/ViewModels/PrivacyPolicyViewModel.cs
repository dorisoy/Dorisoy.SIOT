
namespace SIOT.ViewModels;
public partial class PrivacyPolicyViewModel : ObservableObject
{
    [ObservableProperty]
    string _url;
    public PrivacyPolicyViewModel()
    {
        Url = "http://dorisoy.cn/privacy.html";
    }
}
