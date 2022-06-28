using Android.App;
using Android.Content.PM;
using Android.OS;
using ScorpiusClient.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ScorpiusClient.Droid
{
    [Activity(Label = "ScorpiusClient", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(savedInstanceState);
            Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            DependencyService.Register<IFirebaseService>();
        }
    }
}