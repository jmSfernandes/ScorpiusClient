using Android.App;
using Android.Util;
using Firebase.Messaging;

namespace ScorpiusClient.Droid.Services
{
    [Service]
    [IntentFilter(new[] {"com.google.firebase.MESSAGING_EVENT"})]
    public class FirebaseMessagingReceiverService : FirebaseMessagingService
    {
        //private const string NewsChannelId = "1";
        //private const string NewsChannelDescription = "Alert";
        //private readonly long[] _vibrationPattern = {500, 500, 500, 500, 500, 500, 500, 500, 500};
        //private NotificationManager _notificationManager;
        private const string Tag = "MyFirebaseMessagingService";

        public override void OnNewToken(string newToken)
        {
            base.OnNewToken(newToken);

            Log.Info(Tag, "Firebase Token: " + newToken);
        }

        public override void OnMessageReceived(RemoteMessage remoteMessage)
        {
            base.OnMessageReceived(remoteMessage);

            Log.Debug(Tag, "From:    " + remoteMessage.From);

            var name = string.Empty;

            if (remoteMessage.Data.Count > 0)
            {
                Log.Debug(Tag, "Message data payload: " + remoteMessage.Data);
                name = remoteMessage.Data["message"];
            }


            if (remoteMessage.Data.ContainsKey("type"))
            {
                var rawPayload = remoteMessage.Data["data"];
                NotificationUtils.SendNotification(
                    this,
                    NotificationUtils.DefaultNotificationTitle,
                    remoteMessage.Data["message"],
                    rawPayload,
                    remoteMessage.Data["type"]);
            }

            if (remoteMessage.Data.ContainsKey("message"))
            {
                NotificationUtils.SendNotification(
                    this,
                    NotificationUtils.DefaultNotificationTitle,
                    remoteMessage.Data["message"],
                    null,
                    null);
            }
        }
    }
}