using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstPoussière : MonoBehaviour
{
    [SerializeField] ParticleSystem burst;
    // Start is called before the first frame update
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            burst.Play();
        }
        
    }
}
