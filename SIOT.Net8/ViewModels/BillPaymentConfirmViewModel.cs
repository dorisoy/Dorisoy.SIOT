namespace SIOT.ViewModels;

public partial class BillPaymentConfirmViewModel : ObservableObject
{

    [ObservableProperty]
    private RadarDrawable radarDrawable;


    public BillPaymentConfirmViewModel()
    {
        radarDrawable = new RadarDrawable();
    }

    [RelayCommand]
    private async void PaymentConfirm()
    {
        await PopupAction.DisplayPopup(new BillPaySuccessPopup());
    }
}
