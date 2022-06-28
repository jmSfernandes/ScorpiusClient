using System.Collections.Generic;

namespace ScorpiusClient.Services;

public interface IFirebaseService

{
      void SubscribeToMultipleTopics(IEnumerable<string> topics);
      void SubscribeToSingleTopic(string topic);
    
      void UnSubscribeFromMultipleTopics(IEnumerable<string> topics);
            
      void UnSubscribeFromSingleTopic(string topic);
}