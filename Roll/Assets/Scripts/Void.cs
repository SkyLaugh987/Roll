using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Void : MonoBehaviour
{
    [SerializeField]
    CameraFade fade;

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if(ball != null){
            //timer
            GameManager.Instance.Respawn();
            fade.OnGUI();
            fade.RedoFade();
        }
        //respawn les objets
    }
}
