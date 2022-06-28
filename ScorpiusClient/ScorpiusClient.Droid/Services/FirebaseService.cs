using System;
using System.Collections.Generic;
using Android.Util;
using Firebase.Messaging;
using ScorpiusClient.Droid.Services;
using ScorpiusClient.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseService))]

namespace ScorpiusClient.Droid.Services
{
    public class FirebaseService : IFirebaseService
    {
        private const string Tag = "TopicSubscriptionService";

        public void SubscribeToMultipleTopics(IEnumerable<string> topics)
        {
            foreach (var topic in topics)
            {
                SubscribeToSingleTopic(topic);
            }
        }

        public void UnSubscribeFromMultipleTopics(IEnumerable<string> topics)
        {
            foreach (var topic in topics)
            {
                UnSubscribeFromSingleTopic(topic);
            }
        }

        public void UnSubscribeFromSingleTopic(string topic)
        {
            try
            {
                FirebaseMessaging.Instance.UnsubscribeFromTopic(topic);

                Log.Info(Tag, "Unsubscribed from topic: " + topic);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while Unsubscribing: {0}", ex.Message);
            }
        }

        public void SubscribeToSingleTopic(string topic)
        {
            try
            {
                FirebaseMessaging.Instance.SubscribeToTopic(topic);
                Log.Info(Tag, "Subscribed to new topic: " + topic);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while subscribing: {0}", ex.Message);
            }
        }
    }
}