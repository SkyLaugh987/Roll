using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    Rigidbody rb;
    [SerializeField,Range(1f,10f)]
    float speed;

    private void Start()
    {
        
    }

    private void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(speed*hAxis,0,speed*vAxis),ForceMode.Force);
    }
}
