using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingplatform : MonoBehaviour
{

    float timer = 5f;
    float timerReset = 5f;
    bool startTimer = false;
    Rigidbody platRB;
    // Start is called before the first frame update
    void Start()
    {
        platRB = GetComponent<Rigidbody>();
        Debug.Log(startTimer);

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            Debug.Log(startTimer);

            timer -= Time.deltaTime;
            Debug.Log("timer: " + timer);
            if (timer <= 0)
            {
                ActivateGravity();
                timer = timerReset;
                startTimer = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collides");
        startTimer = true;
        
    }
    private void ActivateGravity()
    {
        if (platRB.isKinematic == true)
            platRB.isKinematic = false;
    }
}
