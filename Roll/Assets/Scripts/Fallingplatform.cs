using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingplatform : MonoBehaviour
{

    float timer = 2f;
    float timerReset = 2f;
    bool startTimer = false;
    Rigidbody platRB;
    Vector3 transformOriginPosition;
    Quaternion transformOriginRotation;
    // Start is called before the first frame update
    void Start()
    {
        platRB = GetComponent<Rigidbody>();
        //Debug.Log(startTimer);

        transformOriginPosition = transform.position;
        transformOriginRotation = transform.rotation;
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
            transform.rotation = transformOriginRotation;
            if (platRB.isKinematic == false)
                platRB.isKinematic = true;
            GameManager.Instance.SetRespawnBool(false);
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
