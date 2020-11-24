using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameTools.MessageSystem;

public class EventDemo : MonoBehaviour
{
    private UnityAction spinListener;
    private UnityAction sleepListener;
    public float yAngle = 1f;
    private bool spin = false;
    public int turnByAngle = 90;
    void Awake ()
    {
        spinListener = new UnityAction (SpinUp);
        sleepListener = new UnityAction (Sleep);
    }

    void OnEnable ()
    {
        EventManager.Instance.StartListening ("Spin", spinListener);
        EventManager.Instance.StartListening ("Sleep", sleepListener);
   
    }

    void OnDisable ()
    {
        // ensure that no memory leak occurs
        if (EventManager.Instance != null)
        {
            EventManager.Instance.StopListening ("Spin", spinListener);
            EventManager.Instance.StopListening ("Sleep", sleepListener);

        }
        
    }

    void Update ()
    {
        int current_angle = -1;
        if (spin)
        {
            transform.Rotate(0, yAngle, 0, Space.World);
        
            current_angle = RoundOff(transform.eulerAngles.y, yAngle);
        }
            
        if (current_angle % turnByAngle == 0)
        {
            spin = false;
            transform.eulerAngles = new Vector3(0, current_angle, 0);
        }
         
    }
    public int RoundOff (float i, float round_by)
    {
        return ((int)Mathf.Round((int)i / round_by)) * (int)round_by;
    }
    void SpinUp()
    {
        
        spin = true;
    }
    void Sleep()
    {
        spin = false;
    }
}
