using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    Rigidbody rb;
    [SerializeField,Range(20f,75f)]
    float speed = 10;
    [SerializeField, Range(20f, 75f)]
    float jumpForce = 10;
    [SerializeField, Range(40f, 120f)]
    float sprintSpeed = 14;
    [SerializeField, Range(1f, 75f)]
    float airborneSpeed = 4;

    [SerializeField]
    float groundDrag = 2f;
    [SerializeField]
    float airDrag = 0.004f;
    [SerializeField]
    KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    KeyCode sprintKey = KeyCode.LeftShift;

    bool sprint = false;

    private void FixedUpdate()
    {
        Vector3 dir = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (!isGrounded())
        {
            rb.AddForce(dir * airborneSpeed,ForceMode.Force);
            rb.AddForce(transform.up + Physics.gravity * 10f);
            rb.drag = airDrag;
        }
        else if(sprint){
            rb.AddForce(dir * sprintSpeed, ForceMode.Force);
        }
        else{
            rb.AddForce(dir * speed, ForceMode.Force);
        }

        if (isGrounded())
        {
            rb.drag = groundDrag;

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
        sprint = false;
    }

    bool isGrounded()
    {
        return Physics.Raycast(this.gameObject.GetComponent<SphereCollider>().bounds.center, Vector2.down, this.gameObject.GetComponent<SphereCollider>().bounds.extents.y+0.04f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
