namespace SIOT;
public partial class MainAppShell : SimpleShell
{
    public ICommand BackCommand { get; set; }
    public MainAppShell()
    {
        BackCommand = new Command(async () =>
        {
            await this.GoToAsync("..");
        });

        InitializeComponent();

        Routing.RegisterRoute(nameof(DemoStartPage), typeof(DemoStartPage));
        Routing.RegisterRoute(nameof(DemoWalkthroughPage), typeof(DemoWalkthroughPage));
        Routing.RegisterRoute(nameof(ImagePage), typeof(ImagePage));
        Routing.RegisterRoute(nameof(DevicePage), typeof(DevicePage));
        Routing.RegisterRoute(nameof(ScanQrPayPage), typeof(ScanQrPayPage));

        Loaded += MainAppShellLoaded;

        this.SetTransition(
                callback: static args =>
                {
                    switch (args.TransitionType)
                    {
                        case SimpleShellTransitionType.Switching:
                            if (args.OriginShellSectionContainer == args.DestinationShellSectionContainer)
                            {
                                args.OriginPage.Opacity = 1 - args.Progress;
                                args.DestinationPage.Opacity = args.Progress;
                            }
                            else
                            {
                                (args.OriginShellSectionContainer ?? args.OriginPage).Opacity = 1 - args.Progress;
                                (args.DestinationShellSectionContainer ?? args.DestinationPage).Opacity = args.Progress;
                            }
                            break;
                        case SimpleShellTransitionType.Pushing:
                            args.DestinationPage.Opacity = args.DestinationPage.Width < 0 ? 0 : 1;
                            args.DestinationPage.TranslationX = (1 - args.Progress) * args.DestinationPage.Width;
                            break;
                        case SimpleShellTransitionType.Popping:
                            args.OriginPage.TranslationX = args.Progress * args.OriginPage.Width;
                            break;
                    }
                },
                duration: static args => 250u,
                finished: static args =>
                {
                    args.DestinationPage.TranslationX = 0;
                    args.OriginPage.TranslationX = 0;
                    args.OriginPage.Opacity = 1;
                    args.DestinationPage.Opacity = 1;
                    if (args.OriginShellSectionContainer is not null)
                        args.OriginShellSectionContainer.Opacity = 1;
                    if (args.DestinationShellSectionContainer is not null)
                        args.DestinationShellSectionContainer.Opacity = 1;
                },
                destinationPageInFront: static args => args.TransitionType switch
                {
                    SimpleShellTransitionType.Pushing => true,
                    _ => false
                },
                easing: static args => args.TransitionType switch
                {
                    SimpleShellTransitionType.Pushing => Easing.SinIn,
                    SimpleShellTransitionType.Popping => Easing.SinOut,
                    _ => Easing.Linear
                });
    }

    protected override bool OnBackButtonPressed()
    {
        System.Diagnostics.Debug.WriteLine($"{nameof(MainAppShell)}: Back button pressed");
        return base.OnBackButtonPressed();
    }

    private void MainAppShellLoaded(object sender, EventArgs e)
    {
        this.Window.SubscribeToSafeAreaChanges(OnSafeAreaChanged);
    }

    private void OnSafeAreaChanged(Thickness safeAreaPadding)
    {
        rootContainer.Padding = new Thickness(0, safeAreaPadding.Top, 0, safeAreaPadding.Bottom);
    }

    private async void ShellItemButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var shellItem = button.BindingContext as BaseShellItem;

        if (!CurrentState.Location.OriginalString.Contains(shellItem.Route))
            await this.GoToAsync($"///{shellItem.Route}", true);
    }

    private async void TabBarItemSelected(object sender, TabItemSelectedEventArgs e)
    {
        if (!CurrentState.Location.OriginalString.Contains(e.ShellItem.Route))
            await this.GoToAsync($"///{e.ShellItem.Route}", true);
    }

    private async void BackButtonClicked(object sender, EventArgs e)
    {
        await this.GoToAsync("..");
    }

    private void ShowPopoverButtonClicked(object sender, EventArgs e)
    {
        var button = sender as View;
        button.ShowAttachedPopover();
    }

    private async void OnSettingsToolbarItemClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ScanQrPayPage));
    }

    private void DesignLanguagesListPopoverItemSelected(object sender, ListPopoverItemSelectedEventArgs e)
    {

    }

    private async void QrScan_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ScanQrPayPage));
    }

    private record DesignLanguageItem(string Title, Action Action)
    {
        public override string ToString() => Title;
    }
}
