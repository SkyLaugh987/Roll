using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (GameManager.Instance.GetRespawn() == this.transform.position)
        {
            return;
        }


        if (other.tag.Equals("Player"))
        {
            GameManager.Instance.SetRespawnPoint(this.transform.position);
        }
    }
}
