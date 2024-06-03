namespace SIOT;

public partial class SampleAppShell : SimpleShell
{
    public SampleAppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DemoStartPage), typeof(DemoStartPage));
        Routing.RegisterRoute(nameof(DemoWalkthroughPage), typeof(DemoWalkthroughPage));
        Routing.RegisterRoute(nameof(ImagePage), typeof(ImagePage));
        Routing.RegisterRoute(nameof(MobileTopupPage), typeof(MobileTopupPage));
        Routing.RegisterRoute(nameof(BillPaymentConfirmPage), typeof(BillPaymentConfirmPage));
        Routing.RegisterRoute(nameof(AllServicePage), typeof(AllServicePage));
        Routing.RegisterRoute(nameof(TransferMoneyPage), typeof(TransferMoneyPage));
        Routing.RegisterRoute(nameof(RequestPaymentPage), typeof(RequestPaymentPage));
        Routing.RegisterRoute(nameof(RequestPaymentDetailsPage), typeof(RequestPaymentDetailsPage));
        //Routing.RegisterRoute(nameof(PaymentConfirmPage), typeof(PaymentConfirmPage));
        Routing.RegisterRoute(nameof(EReceiptPage), typeof(EReceiptPage));
        Routing.RegisterRoute(nameof(ScanQrPayPage), typeof(ScanQrPayPage));
        Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
        Routing.RegisterRoute(nameof(PrivacyPolicyPage), typeof(PrivacyPolicyPage));

        this.SetTransition(
            callback: args =>
            {
                switch (args.TransitionType)
                {
                    case SimpleShellTransitionType.Switching:
                        args.OriginPage.Opacity = 1 - args.Progress;
                        args.DestinationPage.Opacity = args.Progress;
                        break;
                    case SimpleShellTransitionType.Pushing:
                        args.DestinationPage.TranslationX = (1 - args.Progress) * args.DestinationPage.Width;
                        break;
                    case SimpleShellTransitionType.Popping:
                        args.OriginPage.TranslationX = args.Progress * args.OriginPage.Width;
                        break;
                }
            },
            finished: args =>
            {
                args.OriginPage.Opacity = 1;
                args.OriginPage.TranslationX = 0;
                args.DestinationPage.Opacity = 1;
                args.DestinationPage.TranslationX = 0;
            },
            destinationPageInFront: args => args.TransitionType switch
            {
                SimpleShellTransitionType.Popping => false,
                _ => true
            },
            duration: args => args.TransitionType switch
            {
                SimpleShellTransitionType.Switching => 500,
                _ => 350
            });

        Loaded += PlaygroundAppShellLoaded;
    }

    private void PlaygroundAppShellLoaded(object sender, EventArgs e)
    {
        this.Window.SubscribeToSafeAreaChanges(OnSafeAreaChanged);
    }

    private void OnSafeAreaChanged(Thickness safeAreaPadding)
    {
        rootContainer.Padding = safeAreaPadding;
    }

    private async void ShellItemButtonClicked(object sender, EventArgs e)
    {
        var button = sender as ContentButton;
        var shellItem = button.BindingContext as BaseShellItem;

        if (!CurrentState.Location.OriginalString.Contains(shellItem.Route))
            await GoToAsync($"///{shellItem.Route}", true);
    }

    private async void BackButtonClicked(object sender, EventArgs e)
    {
        await GoToAsync("..");
    }
}