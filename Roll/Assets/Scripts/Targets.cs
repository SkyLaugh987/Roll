using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField] GameObject[] targets;
    [SerializeField] float speed;
    [SerializeField] float waitFor;
    int currIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //float waitReset = waitFor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(targets[currIndex].transform.position, transform.position) < 1)
        {
           
            StartCoroutine(Countdown(waitFor));
            currIndex++;

            if (currIndex >= targets.Length)
                currIndex = 0;
        }

        Debug.Log("Departure");
        transform.position = Vector3.MoveTowards(transform.position, targets[currIndex].transform.position, speed * Time.deltaTime);
    }


    IEnumerator Countdown(float seconds)
    {
        Debug.Log("Waiting");
        float counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(seconds);
            counter--;
        }
            transform.position = targets[currIndex].transform.position;

    }
}
