using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager GM;

    [SerializeField] public GameObject pauseMenu, gameOverScene, winScene, finishScene;
    [SerializeField] public Text timerText, timerWinText, ScoreCanvas;

    [HideInInspector] public bool isRestarted = false;
    float timer = 3.4f;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (isRestarted)
        {
            timer -= Time.deltaTime;
            if (gameOverScene.activeSelf)
            {
                timerText.text = Mathf.Round(timer).ToString();
                if (timer <= 0.6f)
                    Restart();
            }
            else if (winScene.activeSelf)
            {
                timerWinText.text = Mathf.Round(timer).ToString();
                if (timer <= 0.6f)
                    nextLvl();
            }
        }
        ScoreCanvas.text = GameManager.score.ToString();
    }

    void nextLvl()
    {
        GameManager.gameStatus = GameManager.GameStatus.gameRunning;
        GM.LockScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue()
    {
        GameManager.gameStatus = GameManager.GameStatus.gameRunning;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        GameManager.gameStatus = GameManager.GameStatus.gameRunning;
        GM.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        GameManager.gameStatus = GameManager.GameStatus.gameRunning;
        GameManager.score = 0;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void FinishGame()
    {
        GameManager.gameStatus= GameManager.GameStatus.gameFinish;
        finishScene.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
