using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UIManager UM;

    private static GameManager _instance;

    public delegate void RecordToT();
    public static event RecordToT Nicolò;


    private void Awake()
    {
        if (GameManager._instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public enum GameStatus
    {
        gamePaused,
        gameRunning,
        gameEnd 
    }

    public static GameStatus gameStatus = GameStatus.gameRunning;

    void Update()
    {
        if (UM == null)
            UM = FindObjectOfType<UIManager>();

        if (Input.GetKeyDown("escape") && gameStatus == GameStatus.gameRunning)
        {
            gameStatus = GameStatus.gamePaused;
            UM.pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown("escape") && gameStatus == GameStatus.gamePaused)
            UM.Continue();
        else if (Input.anyKey && gameStatus == GameStatus.gameEnd)
            UM.isRestarted = true;
    }

    public void EndGame()
    {
        gameStatus = GameStatus.gameEnd;
        UM.endGameScene.SetActive(true);
    }
}