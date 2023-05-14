using Android.App;
using Android.Util;
using Firebase.Messaging;

namespace ScorpiusClient.Droid.Services
{
    public class FirebaseMessageReceiver
    {
        //private const string NewsChannelId = "1";
        //private const string NewsChannelDescription = "Alert";
        //private readonly long[] _vibrationPattern = {500, 500, 500, 500, 500, 500, 500, 500, 500};
        //private NotificationManager _notificationManager;
        private const string Tag = "MyFirebaseMessagingService";


        public static void OnMessageReceived(object message)
        {
            var remoteMessage = message as RemoteMessage;


            if (remoteMessage?.Data.Count > 0)
            {
                Log.Debug(Tag, "Message data payload: " + remoteMessage.Data["message"]);
            }


            if (remoteMessage.Data.ContainsKey("type"))
            {
                var rawPayload = remoteMessage.Data["data"];
                NotificationUtils.SendNotification(
                    Application.Context,
                    NotificationUtils.DefaultNotificationTitle,
                    remoteMessage.Data["message"],
                    rawPayload,
                    remoteMessage.Data["type"]);
            }

            if (remoteMessage.Data.ContainsKey("message"))
            {
                NotificationUtils.SendNotification(
                    Application.Context,
                    NotificationUtils.DefaultNotificationTitle,
                    remoteMessage.Data["message"],
                    null,
                    null);
            }
        }
    }
}