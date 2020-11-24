using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTools.MessageSystem;
public class EventTriggerTest : MonoBehaviour
{
 
    void Update()
    {
        // this could be a collision or timer or anything
        if (Input.GetKeyDown ("q"))
        {
            EventManager.Instance.TriggerEvent ("test");
        }
        
      
    }
}
