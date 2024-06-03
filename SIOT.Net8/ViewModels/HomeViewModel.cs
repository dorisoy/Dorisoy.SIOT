
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
            // await api call;
            await Task.Delay(1000);
            Application.Current.Dispatcher.Dispatch(() =>
            {
                RecentTransactions = new ObservableCollection<TransactionData>(EwalletServices.Instance.GetTransactions);

                IsBusy = false;
            });
        });
    }

    [RelayCommand]
    private async void GotoNotification()
    {
        await Shell.Current.GoToAsync(nameof(NotificationsPage));
    }

    [RelayCommand]
    private async void GotoTopup()
    {
        await Shell.Current.GoToAsync(nameof(MobileTopupPage));
    }

    [RelayCommand]
    private async void GotoTransfer()
    {
        await Shell.Current.GoToAsync(nameof(TransferMoneyPage));
    }

    [RelayCommand]
    private async void GotoRequest()
    {
        await Shell.Current.GoToAsync(nameof(RequestPaymentPage));
    }

    [RelayCommand]
    private async void PayNow()
    {
        await Shell.Current.GoToAsync(nameof(BillPaymentConfirmPage));
    }


    [RelayCommand]
    private async void AllService()
    {
        await Shell.Current.GoToAsync(nameof(AllServicePage));
    }

    [RelayCommand]
    private async void TransactionDetail()
    {
        await Shell.Current.GoToAsync(nameof(EReceiptPage));
    }
}
