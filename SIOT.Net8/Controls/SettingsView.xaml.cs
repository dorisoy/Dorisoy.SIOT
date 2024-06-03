

using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;

namespace SIOT.Controls;

public partial class SettingsView
{
    private object pageBindingContext;
    public ThemePalette SelectedPrimaryColorItem { get; set; }
    public SettingsView()
    {
        InitializeComponent();
        this.BindingContext = AppSettings.AppSettings.Instance;

        var colorItems = new List<ThemePalette>
        {
            new ThemePalette()
            {
                Index = 0,
                Color = Color.FromArgb("#f54e5e")
            },
            new ThemePalette()
            {
                Index = 1,
                Color = Color.FromArgb("#2f72e4")
            },
            new ThemePalette()
            {
                Index = 2,
                Color = Color.FromArgb("#5d4cf7")
            },
            new ThemePalette()
            {
                Index = 3,
                Color = Color.FromArgb("#06846a")
            },
            new ThemePalette()
            {
                Index = 4,
                Color = Color.FromArgb("#d54008")
            }
        };

        //var colors = new List<Color>
        //    {
        //        Color.FromArgb("#f54e5e"),
        //        Color.FromArgb("#2f72e4"),
        //        Color.FromArgb("#5d4cf7"),
        //        Color.FromArgb("#06846a"),
        //        Color.FromArgb("#d54008"),
        //    };

        var viewCollection = new ObservableCollection<ThemePalette>();

        foreach (var colorItem in colorItems)
        {
            //var grid = new Grid();
            //var border = new Border
            //{
            //    Margin = new Thickness(4),
            //    HorizontalOptions = LayoutOptions.Center,
            //    StrokeShape = new RoundRectangle
            //    {
            //        CornerRadius = new CornerRadius(20, 20, 20, 20)
            //    },
            //    Stroke = color,
            //    Content = new BoxView { Color = color },
            //};
            //grid.Children.Add(border);
            viewCollection.Add(colorItem);
        }

        this.colorPaletteCollectionView.ItemsSource = viewCollection;

        this.UpdatePrimaryColor();
        this.colorPaletteCollectionView.SelectionChanged += (sender, e) =>
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as ThemePalette;
            //this.colorPaletteCollection.SelectionIndicatorSettings.Color = colors[e.Index];
            AppSettings.AppSettings.Instance.SelectedPrimaryColor = selectedItem.Index;
        };
    }



    public void Show()
    {
        this.ShowSettingsPage();
    }

    public void Show(object obj)
    {
        this.pageBindingContext = obj;
        this.ShowSettingsPage();
    }

    public void Hide()
    {
        this.ShadowView.IsVisible = false;
        var fadeAnimation = new Animation(v => this.MainContent.Opacity = v, 1, 0);
        var translateAnimation = new Animation(v => this.MainContent.TranslationY = v, 0, this.MainContent.Height, null, () => { this.IsVisible = false; });

        var parentAnimation = new Animation { { 0.5, 1, fadeAnimation }, { 0, 1, translateAnimation } };
        parentAnimation.Commit(this, "HideSettings");
    }

    public void UpdatePrimaryColorItem()
    {
        this.colorPaletteCollectionView.SelectedItem = AppSettings.AppSettings.Instance.SelectedPrimaryColorItem;
    }

    private void ShowSettingsPage()
    {
        this.IsVisible = true;
        this.MainContent.FadeTo(1);
        this.MainContent.TranslateTo(this.MainContent.TranslationX, 0);
        this.ShadowView.IsVisible = true;
    }

    private void OnClose_Tapped(object sender, EventArgs e)
    {
        this.Hide();
    }

    private void CloseSettings(object sender, EventArgs e)
    {
        this.Hide();
    }

    private void OnSettingLightTheme_Clicked(object sender, EventArgs e)
    {
        Application.Current.Resources.ApplyLightTheme();
        //this.PrimaryColorsView.SelectedIndex = 0;
        //SelectedPrimaryColorItem = AppSettings.AppSettings.Instance.SelectedPrimaryColorItem;
        AppSettings.AppSettings.Instance.SelectedPrimaryColor = 0;
        this.UpdatePrimaryColor();
    }

    private void OnSettingDarkTheme_Clicked(object sender, EventArgs e)
    {
        Application.Current.Resources.ApplyDarkTheme();
        //this.PrimaryColorsView.SelectedIndex = 1;
        //SelectedPrimaryColorItem = AppSettings.AppSettings.Instance.SelectedPrimaryColorItem;
        AppSettings.AppSettings.Instance.SelectedPrimaryColor = 1;
        this.UpdatePrimaryColor();
    }

    private void colorPaletteCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as ThemePalette;
        SelectedPrimaryColorItem = selectedItem;
        AppSettings.AppSettings.Instance.SelectedPrimaryColor = selectedItem.Index;
        this.UpdatePrimaryColor();
    }
    private void UpdatePrimaryColor()
    {
        Application.Current.Resources.TryGetValue("PrimaryColor", out var primaryColor);
        Application.Current.Resources.TryGetValue("White", out var white);
        Application.Current.Resources.TryGetValue("Gray600", out var gray600);
        Application.Current.Resources.TryGetValue("Black", out var black);

        if (AppSettings.AppSettings.Instance.IsDarkTheme == false)
        {
            this.lightThemeButton.BackgroundColor = (Color)primaryColor;
            this.lightThemeButton.TextColor = (Color)white;
            this.darkThemeButton.BackgroundColor = (Color)gray600;
            this.darkThemeButton.TextColor = (Color)black;
        }
        else
        {
            this.lightThemeButton.BackgroundColor = (Color)gray600;
            this.lightThemeButton.TextColor = (Color)black;
            this.darkThemeButton.BackgroundColor = (Color)primaryColor;
            this.darkThemeButton.TextColor = (Color)white;
        }
    }
}