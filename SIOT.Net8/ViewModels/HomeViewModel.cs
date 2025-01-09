
namespace SIOT.ViewModels;
public partial class HomeViewModel : ObservableObject
{

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    public ObservableCollection<TransactionData> _recentTransactions;

    public HomeViewModel()
    {
        LoadData();
    }

    void LoadData()
    {
        Task.Run(async () =>
        {
            IsBusy = true;
            await Task.Delay(1000);
            Application.Current.Dispatcher.Dispatch(() =>
            {
                RecentTransactions = new ObservableCollection<TransactionData>(EwalletServices.Instance.GetTransactions);

                IsBusy = false;
            });
        });
    }
}
