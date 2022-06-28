using System.Collections.Generic;
using Android.Util;
using Firebase.Messaging;
using ScorpiusClient.Droid.Services;
using ScorpiusClient.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseService))]

namespace ScorpiusClient.Droid.Services{

public class FirebaseService : IFirebaseService
{
    private const string Tag = "TopicSubscriptionService";

    public void SubscribeToMultipleTopics(IEnumerable<string> topics)
    {
        foreach (var id in topics) {
            FirebaseMessaging.Instance.SubscribeToTopic(id);

            Log.Info(Tag, "Subscribed to topic: " + id);
        }
    }

    public void UnSubscribeFromMultipleTopics(IEnumerable<string> topics)
    {
        foreach (var id in topics) {
            FirebaseMessaging.Instance.UnsubscribeFromTopic(id);

            Log.Info(Tag, "[Multiple] Unsubscribed from topic: " + id);
        }
    }

    public void UnSubscribeFromSingleTopic(string topic)
    {
        FirebaseMessaging.Instance.UnsubscribeFromTopic(topic);

        Log.Info(Tag, "Unsubscribed from topic: " + topic);
    }

    public void SubscribeToSingleTopic(string topic)
    {
        FirebaseMessaging.Instance.SubscribeToTopic(topic);

        Log.Info(Tag, "Subscribed to new topic: " + topic);
    }
}
}