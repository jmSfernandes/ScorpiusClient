using Android.App;
using Android.Content.PM;
using Android.OS;
using Firebase.Messaging;
using ScorpiusClient.Droid.Services;
using ScorpiusClientLibrary;
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

            CrossScorpiusClient.Current.Init(this);
            CrossScorpiusClient.Current.SetCallback(FirebaseMessageReceiver.OnMessageReceived);
        }
    }
}