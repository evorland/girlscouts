// ----------------------------------------------------------------------------
// Scriptable Object Game Event
// 
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace AngryBirds
{
    [CreateAssetMenu]
    public class Event : ScriptableObject
    {
        /// <summary>
        /// The list of subscribers that this event will notify if it is raised.
        /// </summary>
        private readonly List<EventSubscriber> subscribers = 
            new List<EventSubscriber>();

        public void Raise()
        {
            // On Raise, all subscribers to the event will receive an update
            // and each subscriber will react according to the logic contained in their
            // respective OnEventRaised methods.
            for(int i = subscribers.Count -1; i >= 0; i--)
                subscribers[i].OnEventRaised();
        }

        public void RegisterSubscriber(EventSubscriber subscriber)
        {
            // If the passed subscriber does not already exist in current subscriber list,
            // add it to the list of subscribers. The subscriber will now receive updates
            // from the event.
            if (!subscribers.Contains(subscriber))
                subscribers.Add(subscriber);
        }

        public void UnregisterSubscriber(EventSubscriber subscriber)
        {
            // If the passed subscriber exists in current subscriber list,
            // remove it. The subscriber will no longer receive updates
            // from the event.
            if (subscribers.Contains(subscriber))
                subscribers.Remove(subscriber);
        }
    }
}