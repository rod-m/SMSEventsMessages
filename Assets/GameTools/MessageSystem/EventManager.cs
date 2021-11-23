using System.Collections.Generic;
using Singletons;
using UnityEngine;
using UnityEngine.Events;

namespace GameTools.MessageSystem
{
    public sealed class EventManager : GenericSingleton<EventManager>
    {
        private Dictionary<string, UnityEvent> eventDictionary = new Dictionary<string, UnityEvent>();
        
        public override void Awake()
        { 
            
            base.Awake();
          
        }
    
        public void StartListening (string eventName, UnityAction listener)
        {
            UnityEvent thisEvent = null;
            Debug.Log($"StartListen {Instance.name}");
            if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
            {
                thisEvent.AddListener (listener);
            } 
            else
            {
                thisEvent = new UnityEvent ();
                thisEvent.AddListener (listener);
                Instance.eventDictionary.Add (eventName, thisEvent);
            }
        }

        public void StopListening (string eventName, UnityAction listener)
        {
            if (Instance == null) return;
            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
            {
                thisEvent.RemoveListener (listener);
            }
        }

        public void TriggerEvent (string eventName)
        {
            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
            {
                thisEvent.Invoke ();
            }
        }
    }

}
