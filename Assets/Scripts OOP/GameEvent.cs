using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mhmtbtn
{
    [CreateAssetMenu(menuName = "Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        [NonSerialized] private List<EventListener> eventListeners = new List<EventListener>();

        public void Raise()
        {
            foreach (EventListener eventListener in eventListeners)
            {
                eventListener.OnEventRaised(eventListener.Response);
            }
        }

        public void RegisterListener(EventListener eventListener)
        {
            if (!eventListeners.Contains(eventListener)) eventListeners.Add(eventListener);
        }

        public void UnregisterListener(EventListener eventListener)
        {
            if (eventListeners.Contains(eventListener)) eventListeners.Remove(eventListener);
        }
    }
}