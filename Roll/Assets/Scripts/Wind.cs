using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField,Range(0.1f,10f)]
    float windForce = 1f;

    [SerializeField]
    Vector3 windDir;

    private void OnTriggerStay(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ball.gameObject.GetComponent<Rigidbody>().AddForce(windDir * windForce / 5, ForceMode.Acceleration);
        }
    }
}
