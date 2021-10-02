using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    Rigidbody rb;
    [SerializeField,Range(1f,25f)]
    float speed = 10;
    [SerializeField, Range(1f, 25f)]
    float jumpForce = 10;
    [SerializeField, Range(1f, 25f)]
    float sprintSpeed = 14;
    [SerializeField, Range(1f, 25f)]
    float airborneSpeed = 4;

    [SerializeField]
    KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    KeyCode sprintKey = KeyCode.LeftShift;

    bool sprint = false;
    bool airborne = false;

    private void Update()
    {
        Vector3 dir = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (airborne){
            rb.AddForce(dir * airborneSpeed,ForceMode.Force);
        }
        else if(sprint){
            rb.AddForce(dir * sprintSpeed, ForceMode.Force);
        }
        else{
            rb.AddForce(dir * speed, ForceMode.Force);
        }

        if (!airborne)
        {
            if (Input.GetKeyDown(jumpKey)){
                Jump();
            }
            else if(Input.GetKey(sprintKey)){
                sprint = true;
            }
            else{
                sprint = false;
            }
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        airborne = true;
        sprint = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        airborne = false;
    }
}
