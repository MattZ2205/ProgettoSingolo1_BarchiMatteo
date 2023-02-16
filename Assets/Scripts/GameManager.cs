using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //UIManager UM;

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
        gameEnd,
        gameStart
    }

    public GameStatus gameStatus = GameStatus.gameRunning;

    // Update is called once per frame
    void Update()
    {
        //if (UM == null)
        //    UM = FindObjectOfType<UIManager>();

        //if (Input.GetKeyDown("escape") && gameStatus == GameStatus.gameRunning)
        //{
        //    gameStatus = GameStatus.gamePaused;
        //    UM.pauseMenu.SetActive(true);
        //}
        //else if (Input.GetKeyDown("escape") && gameStatus == GameStatus.gamePaused)
        //    UM.Continue();
        //else if (Input.GetKeyDown(KeyCode.R) && gameStatus == GameStatus.gameEnd)
        //    UM.Restart();
    }

    public void EndGame()
    {
        gameStatus = GameStatus.gameEnd;
        Nicolò?.Invoke();
    }
}