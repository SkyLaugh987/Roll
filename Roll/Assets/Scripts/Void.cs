using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    [SerializeField]
    Transform respawn;

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if(ball != null){
            ball.gameObject.transform.position = respawn.position;
        }
        //respawn objets
    }
}
