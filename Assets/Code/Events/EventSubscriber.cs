// ----------------------------------------------------------------------------
// Scriptable Object Event Subscriber
// 
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.Events;

namespace AngryBirds
{
    public class EventSubscriber : MonoBehaviour
    {
        /// <summary>
        /// This class represents a Subscriber to an Event.
        /// </summary>

        [Tooltip("Event to register with.")]
        public Event Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            // When a Subscriber is enabled, register as a Subscriber to the Event!
            Event.RegisterSubscriber(this);
        }

        private void OnDisable()
        {
            // When a Subscriber is disabled, unregister as a Subscriber to the Event.
            Event.UnregisterSubscriber(this);
        }

        public void OnEventRaised()
        {
            // When the OnEventRaised method is invoked by the Event object (see Raise() in Event.cs),
            // Invoke a Response using the UnityEvent object for this Subscriber.
            Response.Invoke();
        }
    }
}