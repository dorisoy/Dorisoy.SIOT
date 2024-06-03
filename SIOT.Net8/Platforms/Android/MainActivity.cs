using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidX.Core.View;

namespace SIOT
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                // 使状态栏透明
                //Window?.AddFlags(WindowManagerFlags.TranslucentStatus);
                //Window?.ClearFlags(WindowManagerFlags.TranslucentStatus);
                Window?.SetStatusBarColor(Android.Graphics.Color.ParseColor("#2566dc"));
            }



            //Uncomment to set Hide Navigation Bar
            //if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.R)
            //{
            //    Window.SetDecorFitsSystemWindows(false);
            //    var windowInsetsController = Window.DecorView.WindowInsetsController;
            //    if (windowInsetsController != null)
            //    {
            //        windowInsetsController.Hide(WindowInsetsCompat.Type.NavigationBars());
            //    }
            //}
            //else
            //{
            //    var uiOptions = SystemUiFlags.HideNavigation;
            //    Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            //}
        }
    }
}
