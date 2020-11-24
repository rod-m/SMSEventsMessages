using UnityEngine;
using UnityEngine.Events;
using GameTools.MessageSystem;
public class EventTest : MonoBehaviour {

    private UnityAction someListener;

    void Awake ()
    {
        someListener = new UnityAction (DoSomething);
        someListener += SomeOtherFunction;
    }

    void OnEnable ()
    {
        EventManager.Instance.StartListening ("test", someListener);
        EventManager.Instance.StartListening ("Spawn", SomeOtherFunction);
        EventManager.Instance.StartListening ("Destroy", SomeThirdFunction);
    }

    void OnDisable ()
    {
        EventManager.Instance.StopListening ("test", someListener);
        EventManager.Instance.StopListening ("Spawn", SomeOtherFunction);
        EventManager.Instance.StopListening ("Destroy", SomeThirdFunction);
    }

    void DoSomething ()
    {
        Debug.Log ("Some Function was called!");
    }
    
    void SomeOtherFunction ()
    {
        Debug.Log ("Some Other Function was called!");
    }
    
    void SomeThirdFunction ()
    {
        Debug.Log ("Some Third Function was called!");
    }
}