using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingplatform : MonoBehaviour
{

    float timer = 2f;
    float timerReset = 2f;
    bool startTimer = false;
    Rigidbody platRB;

    private Vector3 transformOriginPosition;
    void Start()
    {
        platRB = GetComponent<Rigidbody>();
        //Debug.Log(startTimer);
        transformOriginPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            //Debug.Log(startTimer);

            timer -= Time.deltaTime;
            Debug.Log("timer: " + timer);
            if (timer <= 0)
            {
                ActivateGravity();
                timer = timerReset;
                startTimer = false;
            }
        }

        if (GameManager.Instance.GetRespawnBool())
        {
            transform.position = transformOriginPosition;

            if (platRB.isKinematic == false)
                platRB.isKinematic = true;

            if (this.transform.position == transformOriginPosition)
            {
                GameManager.Instance.SetRespawnBool(false);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Debug.Log("collides");
            startTimer = true;
        }

    }
    private void ActivateGravity()
    {
        if (platRB.isKinematic == true)
            platRB.isKinematic = false;
    }
}
