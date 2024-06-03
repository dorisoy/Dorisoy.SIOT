
using SIOT.ViewModels.FontIcons;
using System.Collections.ObjectModel;

namespace SIOT.Views;

public partial class FontIconsPage : ContentPage
{
    public FontIconsPage()
    {
        InitializeComponent();
        BindingContext = new FontIconsViewModel();
    }

    void Handle_TextChanged(object sender, TextChangedEventArgs e)
    {
        var _container = BindingContext as FontIconsViewModel;
        iconsListView.BeginRefresh();

        if (string.IsNullOrWhiteSpace(e.NewTextValue))
            iconsListView.ItemsSource = _container.FontIconGroup;
        else
            iconsListView.ItemsSource = _container.FontIconGroup.Select(x =>
            new FontIconGroupModel
                (
                    x.GroupName,
                    x.Where(y => y.Name.IndexOf(e.NewTextValue, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList()
                )
            ).ToList();

        iconsListView.EndRefresh();
    }
}