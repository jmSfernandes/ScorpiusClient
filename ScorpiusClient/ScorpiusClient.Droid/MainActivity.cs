using System;
using Android.App;
using Android.Content.PM;
using Android.Gms.Common;
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

            if (!IsPlayServicesAvailable())
            {
                GoogleApiAvailability.Instance.MakeGooglePlayServicesAvailable(this);
            }

            Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            DependencyService.Register<IFirebaseService>();
        }

        private bool IsPlayServicesAvailable()
        {
            var resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Console.WriteLine(GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    Console.WriteLine("This device is not supported.");
                    Finish();
                }

                return false;
            }

            Console.WriteLine("Google Play Services is available.");
            return true;
        }
    }
}