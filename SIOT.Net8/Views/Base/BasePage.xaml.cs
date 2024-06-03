namespace SIOT.Views;

public partial class BasePage : ContentPage
{
	public IList<Microsoft.Maui.IView> PageContent => PageContentGrid.Children;
	public BasePage()
	{
		InitializeComponent();
	}
}