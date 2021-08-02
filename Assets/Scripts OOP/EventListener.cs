using System;
using UnityEngine.Events;

namespace Mhmtbtn
{
    [Serializable]
    public class EventListener
    {
        public GameEvent Event;
        public UnityEvent Response;
        
        public void OnEventRaised(UnityEvent response)
        {
            response.Invoke();
        }
    }
}