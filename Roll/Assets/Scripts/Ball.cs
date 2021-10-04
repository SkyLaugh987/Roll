using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    Rigidbody rb;
    public Rigidbody Rb { get => rb; set => rb = value; }


    [SerializeField, Range(1f, 75f)]
    float speed = 10;
    [SerializeField, Range(1f, 120f)]
    float jumpForce = 10;
    [SerializeField, Range(1f, 120f)]
    float sprintSpeed = 14;
    [SerializeField, Range(1f, 75f)]
    float airborneSpeed = 4;

    private Vector3 dir;
    private bool jump = false;

    [SerializeField]
    float groundDrag = 2f;
    [SerializeField]
    float airDrag = 0.004f;
    [SerializeField]
    KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    KeyCode sprintKey = KeyCode.LeftShift;

    bool sprint = false;


    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material = MenuManager.Instance.chooseSkin();
    }
    private void FixedUpdate()
    {
        if (!isGrounded())
        {
            Rb.AddForce(dir * airborneSpeed, ForceMode.Force);
            Rb.AddForce(transform.up + Physics.gravity * 10f);
            Rb.drag = airDrag;
        }
        else if (sprint)
        {
            Rb.AddForce(dir * sprintSpeed, ForceMode.Force);
        }
        else
        {
            Rb.AddForce(dir * speed, ForceMode.Force);
        }

        if (isGrounded())
        {
            Rb.drag = groundDrag;
            Jump();

        }
        
        
    }

    private void Update()
    {
        ReadingInput();
        Debug.Log(GameManager.Instance.GameState);
    }

    private void ReadingInput()
    {
        dir = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (isGrounded())
        {

            if (Input.GetKeyDown(jumpKey))
            {
                jump = true;
            }


            if (Input.GetKey(sprintKey))
            {
                sprint = true;
            }
            else
            {
                sprint = false;
            }
        }
    }

    void Jump()
    {
        if (jump)
        {
            Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            sprint = false;
            jump = false;
        }

    }

    bool isGrounded()
    {
        return Physics.Raycast(this.gameObject.GetComponent<SphereCollider>().bounds.center, Vector2.down, this.gameObject.GetComponent<SphereCollider>().bounds.extents.y + 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
