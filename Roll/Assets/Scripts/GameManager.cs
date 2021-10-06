using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    CameraFade fade;

    private bool victory;
    public bool Victory { get => victory; set => victory = value; }
    private Vector3 respawnPoint;
    private bool respawned = false;
    [SerializeField] Ball ball;

    #region Instances;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("GameManager Instance not found.");

            return instance;
        }

    }

    #endregion

    private void OnEnable()
    {
        instance = this;
    }

    #region GameStates;
    public enum GameStates
    {
        MainMenu,
        InGame,
        Pause,
        GameOver,
        Win,
    }
    private GameStates currentGameState;
    public GameStates GameState
    {
        get => currentGameState;
        set
        {
            currentGameState = value;
            switch (currentGameState)
            {
                case GameStates.MainMenu:
                    Time.timeScale = 1;

                    break;

                case GameStates.InGame:
                    Time.timeScale = 1;
                    UIManager.Instance.Hide();
                    break;

                case GameStates.Win:
                    Time.timeScale = 0;
                    UIManager.Instance.DisplayVictory();

                    break;
            }
        }
    }
    #endregion;


    public List<Transform> platformOriginPos;

    public void Respawn()
    {

        ball.Rb.velocity = Vector3.zero;
        ball.transform.position = respawnPoint;
        fade.OnGUI();
        fade.RedoFade();
        respawned = true;
        
    }

    public Vector3 GetRespawn()
    {
        return respawnPoint;
    }


    public void SetRespawnPoint(Vector3 respawn)
    {
        respawnPoint = respawn;
    }

    public void SetVictory()
    {

        GameState = GameStates.Win;
        Debug.Log("coucou");
    }

    public bool GetRespawnBool()
    {
        return respawned;
    }

    public void SetRespawnBool(bool res)
    {
        this.respawned = res;
    }

}
