using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameTools.MessageSystem
{
    
    public class EventManager : MonoBehaviour
    {
        private Dictionary<string, UnityEvent> eventDictionary;
        private static EventManager _eventManager;
    
        public static EventManager Instance
        {
            get
            {
                if (!_eventManager)
                {
                    _eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
                    if (!_eventManager)
                    {
                        Debug.LogError("You need a active EventManager in the scene!");
                    }
                    else
                    {
                        // _eventManager initialise
                        _eventManager.Init();
                    }
                }

                return _eventManager;
            }
        }

        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, UnityEvent>();
            }
        }
    
        public static void StartListening (string eventName, UnityAction listener)
        {
            UnityEvent thisEvent = null;
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

        public static void StopListening (string eventName, UnityAction listener)
        {
            if (_eventManager == null) return;
            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
            {
                thisEvent.RemoveListener (listener);
            }
        }

        public static void TriggerEvent (string eventName)
        {
            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
            {
                thisEvent.Invoke ();
            }
        }
    }

}
