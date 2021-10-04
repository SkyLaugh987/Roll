using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField,Range(0.1f,10f)]
    float windForce = 1f;

    
    [SerializeField,Header("Add 1 or -1 to change wind direction, " 
        + "particules have to be turned manually")]
    Vector3 windDir;

    [SerializeField]
    ParticleSystem ps;

    private void Start()
    {
        ps.transform.localRotation = Quaternion.Euler(windDir);
    }

    private void OnTriggerStay(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null){
            ball.gameObject.GetComponent<Rigidbody>().AddForce(windDir * windForce, ForceMode.Acceleration);
        }
    }
}
