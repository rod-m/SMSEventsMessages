using UnityEngine;
using UnityEngine.Events;
using GameTools.MessageSystem;
public class EventTest : MonoBehaviour {

    private UnityAction testListener;

    void Awake ()
    {
        testListener = new UnityAction (DoSomething);
        testListener += SomeOtherFunction;
    }

    void OnEnable ()
    {
        EventManager.Instance.StartListening (EventOption.Test.ToString(), testListener);

    }

    void OnDisable ()
    {
   
        EventManager.Instance.StopListening (EventOption.Test.ToString(), testListener);
    }
    void DoSomething ()
    {
        Debug.Log ("Some Function was called!");
    }
    void SomeOtherFunction ()
    {
        Debug.Log ("Some Other Function was called!");
    }
}