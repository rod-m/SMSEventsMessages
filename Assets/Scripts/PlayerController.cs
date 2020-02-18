using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTools.MessageSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 m_EulerAngleVelocity;
    public float speed = 10f;
    public float rotationSpeed = 100.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {     
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        m_EulerAngleVelocity.y += moveHorizontal * rotationSpeed;
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity);
        rb.MoveRotation(deltaRotation);
        rb.AddForce(transform.forward * speed * moveVertical);
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

 
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            EventManager.TriggerEvent ("Spin");
        }
     
    }
}
