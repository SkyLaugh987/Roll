using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Void : MonoBehaviour
{
    [SerializeField]
    Transform respawn;
    [SerializeField]
    CameraFade fade;

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if(ball != null){
            //timer
            ball.gameObject.transform.position = respawn.position;//ajouter points de passage
            fade.OnGUI();
            fade.RedoFade();
        }
        //respawn les objets
    }
}
