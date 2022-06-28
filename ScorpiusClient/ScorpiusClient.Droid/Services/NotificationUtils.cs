using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using ScorpiusClient.Droid.Services;
using Xamarin.Forms;
using Application = Android.App.Application;
using Color = Android.Graphics.Color;
using NotificationCompat = AndroidX.Core.App.NotificationCompat;

[assembly: Dependency(typeof(NotificationUtils))]

namespace ScorpiusClient.Droid.Services
{
    public class NotificationUtils
    {
        public static string DefaultNotificationTitle = "Scorpius Client";
        private const string NewsChannelId = "1";
        private const string NewsChannelDescription = "Alert";
        private static readonly long[] VibrationPattern = {500, 500, 500, 500, 500, 500, 500, 500, 500};
        private static NotificationManager _notificationManager;


        public void SendNotification(string title, string message, string payload, string typ)
        {
            SendNotification(Application.Context, title, message, payload, typ);
        }

        public static void SendNotification(Context mContext, string title, string message, string payload, string type)
        {
            var intent = new Intent(mContext, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.SingleTop);
            intent.PutExtra("type", type);
            intent.PutExtra("payload", payload);
            intent.PutExtra("title", title);

            var pendingIntent = PendingIntent.GetActivity(mContext, 0, intent, PendingIntentFlags.OneShot);
            _notificationManager = (NotificationManager) mContext.GetSystemService(Context.NotificationService);

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                const NotificationImportance importance = NotificationImportance.High;
                var notificationChannel = new NotificationChannel(NewsChannelId, NewsChannelDescription, importance);

                notificationChannel.EnableLights(true);
                notificationChannel.LightColor = Color.Red;
                notificationChannel.EnableVibration(true);
                notificationChannel.SetSound(
                    RingtoneManager.GetDefaultUri(RingtoneType.Notification),
                    new AudioAttributes.Builder()
                        .SetContentType(AudioContentType.Sonification)
                        ?.SetUsage(AudioUsageKind.Notification)
                        ?.Build());

                if (_notificationManager != null) _notificationManager.CreateNotificationChannel(notificationChannel);
            }

            var notification = new NotificationCompat.Builder(mContext, NewsChannelId)
                .SetLargeIcon(BitmapFactory.DecodeResource(mContext.Resources, Android.Resource.Drawable.StarOn))
                .SetSmallIcon(Android.Resource.Drawable.StarOn)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetAutoCancel(true)
                .SetVisibility((int) NotificationVisibility.Public)
                .SetContentIntent(pendingIntent)
                .SetVibrate(VibrationPattern)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
                .Build();

            _notificationManager.Notify(0,
                notification); // overrides old notification if it's still visible because it uses same Id
        }
    }
}