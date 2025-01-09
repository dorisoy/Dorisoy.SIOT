namespace SIOT.Views;

public partial class DevicePage : ContentPage
{
	public DevicePage()
	{
		InitializeComponent();
		BindingContext = new DeviceViewModel();
	}
}