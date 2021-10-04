using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingplatform : MonoBehaviour
{

    float timer = 1.5f;
    float timerReset = 1.5f;
    float timerPos = 1.5f;
    float timerPosReset;
    bool startTimer = false;
    Rigidbody platRB;

    private Vector3 transformOriginPosition;
    private Quaternion transformOriginRotation;
    void Start()
    {
        platRB = GetComponent<Rigidbody>();
        //Debug.Log(startTimer);
        transformOriginPosition = transform.position;
        transformOriginRotation = transform.rotation;
        timerPosReset = timerPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            //Debug.Log(startTimer);

            timer -= Time.deltaTime;
            //Debug.Log("timer: " + timer);
            if (timer <= 0)
            {
                ActivateGravity();
                timer = timerReset;
                startTimer = false;
            }
        }

        if (GameManager.Instance.GetRespawnBool())
        {
            ResetPos();
            timerPos -= Time.deltaTime;
            if(timerPos <= 0)
            {
                GameManager.Instance.SetRespawnBool(false);
                timerPos = timerPosReset;

            }
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            //Debug.Log("collides");
            startTimer = true;
        }

    }
    private void ActivateGravity()
    {
        if (platRB.isKinematic == true)
            platRB.isKinematic = false;
    }

    public void ResetPos()
    {
        transform.position = transformOriginPosition;
        transform.rotation = transformOriginRotation;

        if (platRB.isKinematic == false)
            platRB.isKinematic = true;

    }
}
