using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.SetVictory();
    }
}
