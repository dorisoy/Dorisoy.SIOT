#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

#if ANDROID
using AndroidX.Core.View;
using AndroidX.AppCompat.App;
using Android.Views;
using Android.OS;
using AView = Android.Views.View;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
#endif

using Microsoft.Maui.LifecycleEvents;
using SkiaSharp.Views.Maui.Controls.Hosting;
using CommunityToolkit.Maui;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


namespace SIOT
{
    public static class MauiProgram
    {
        /// <summary>
        /// 3 configurable AppShellType: Main, Simple, Normal
        /// </summary>
        internal const AppShellType UsedAppShell = AppShellType.Main;
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .UseSkiaSharp(true)

#if !WINDOWS
            .UseMauiMaps()
#endif
            .UseBarcodeReader()
            .RegisterServices()
            .RegisterViews()
            .RegisterViewModels()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Poppins-Regular.otf", "RegularFont");
                fonts.AddFont("Poppins-Medium.otf", "MediumFont");
                fonts.AddFont("Poppins-SemiBold.otf", "SemiBoldFont");
                fonts.AddFont("Poppins-Bold.otf", "BoldFont");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Font-Awesome-Solid.otf", "FontAwesomeSolid");

                fonts.AddFont("fa-solid-900.ttf", "FaPro");
                fonts.AddFont("fa-brands-400.ttf", "FaBrands");
                fonts.AddFont("fa-regular-400.ttf", "FaRegular");
                fonts.AddFont("line-awesome.ttf", "LineAwesome");
                fonts.AddFont("material-icons-outlined-regular.otf", "MaterialDesign");
                fonts.AddFont("ionicons.ttf", "IonIcons");
                fonts.AddFont("icon.ttf", "MauiKitIcons");
            })
            .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler(typeof(CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
                    handlers.AddHandler(typeof(CameraView), typeof(CameraViewHandler));
                    handlers.AddHandler(typeof(BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
                });

            builder.UseSimpleToolkit();

#if ANDROID
                    builder.SetDefaultStatusBarAppearance(color: Microsoft.Maui.Graphics.Colors.Transparent, lightElements: false);
                    builder.SetDefaultNavigationBarAppearance(color: Microsoft.Maui.Graphics.Colors.Transparent, lightElements: false);
#endif

            if (UsedAppShell is not AppShellType.Normal)
            {
                builder.UseSimpleShell();
            }

            builder.Services.AddLocalization();

#if WINDOWS
            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(window =>
                    {
                        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                        AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);

                        //https://github.com/dotnet/maui/issues/7751
                        window.ExtendsContentIntoTitleBar = false; // must be false or else you see some of the buttons
                        winuiAppWindow.SetPresenter(AppWindowPresenterKind.Default);

                        //https://github.com/dotnet/maui/issues/6976
                        var displayArea = Microsoft.UI.Windowing.DisplayArea.GetFromWindowId(win32WindowsId, Microsoft.UI.Windowing.DisplayAreaFallback.Nearest);

                        int width = displayArea.WorkArea.Width * 2 / 3;
                        int height = displayArea.WorkArea.Height - 10;

                        winuiAppWindow.MoveAndResize(new RectInt32(15, 10, width, height));
                    });
                });
            });
#endif


            return builder.Build();
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IBiometricAuthenticationService, BiometricAuthenticationService>();
            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<LoginFingerPrintPage>();
            mauiAppBuilder.Services.AddTransient<LoginStyle1Page>();
            mauiAppBuilder.Services.AddTransient<MainAppShell>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<LoginFingerPrintViewModel>();
            mauiAppBuilder.Services.AddTransient<LoginViewModel>();

            return mauiAppBuilder;
        }
    }
}
