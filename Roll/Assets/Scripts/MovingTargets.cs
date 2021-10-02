using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargets : MonoBehaviour
{
    [SerializeField] GameObject[] targets;
    [SerializeField] float speed;
    int currIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(targets[currIndex].transform.position, transform.position) < 1)
        {
            currIndex++;
            if (currIndex >= targets.Length)
                currIndex = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, targets[currIndex].transform.position, speed * Time.deltaTime);
    }
}
