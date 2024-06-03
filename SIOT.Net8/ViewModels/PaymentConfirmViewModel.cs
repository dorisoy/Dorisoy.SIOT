namespace SIOT.ViewModels;

public partial class PaymentConfirmViewModel : ObservableObject
{
    public PaymentConfirmViewModel()
    {

    }

    [RelayCommand]
    private async void PaymentConfirm()
    {
        await PopupAction.DisplayPopup(new TransferSuccessPopup());
    }
}
