using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UIManager UM;

    [HideInInspector] public float playerHP = 100;
    [HideInInspector] public static float score;
    float levelScore;

    private static GameManager _instance;

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
        gameFinish
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

    public void LockScore()
    {
        levelScore = score;
    }

    public void ResetScore()
    {
        score = levelScore;
    }

    public void LoseGame()
    {
        playerHP = 100;
        gameStatus = GameStatus.gameEnd;
        UM.gameOverScene.SetActive(true);
    }
}