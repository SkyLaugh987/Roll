using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool victory;
    public bool Victory { get => victory; set => victory = value; }
    private Transform respawnPoint;

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

                    break;

                case GameStates.Pause:
                    Time.timeScale = 0;
                    break;

                case GameStates.GameOver:
                    //Affiche un GameOver quoi
                    Time.timeScale = 0;
                    break;

                case GameStates.Win:
                    Time.timeScale = 1;
                    break;
            }
        }
    }
    #endregion;

    public void Respawn()
    {
        //récupérer la boule
        //revenir au dernier endroit passé
        //
    }

    public void SetRespawnPoint(Transform respawn)
    {
        respawnPoint = respawn;
    }


}
