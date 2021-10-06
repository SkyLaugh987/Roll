using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarRespawn : MonoBehaviour
{

    private Vector3 transformOriginPosition;
    private Quaternion transformOriginRotation;
    private Rigidbody RbPillar;

    void Start()
    {
        RbPillar = this.GetComponent<Rigidbody>();
        transformOriginPosition = transform.position;
        transformOriginRotation = transform.rotation;
    }
    

    void Update()
    {
        if (GameManager.Instance.GetRespawnBool())
        {
            ResetPos();
        }
    }


    public void ResetPos()
    {
        transform.position = transformOriginPosition;
        transform.rotation = transformOriginRotation;

        RbPillar.velocity = Vector3.zero;

    }
}
