using Android.App;
using Android.OS;
using Android.Webkit;

namespace MauiAppCalmaMente;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
    ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
                           Android.Content.PM.ConfigChanges.Orientation)]
public class MainActivity : MauiAppCompatActivity
{
}