using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject EcranVictoire;



    public void DisplayVictory()
    {
        EcranVictoire.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Hide()
    {
        EcranVictoire.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }


    public void Button(string state)
    {
        switch (state)
        {

        }
    }

}
