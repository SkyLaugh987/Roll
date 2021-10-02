using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton;
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    void Awake()
    {
        _instance = this;
    }



    public void DisplayPauseMenu()
    {

    }

}
