using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu, gameOverScene, winScene, finishScene;
    [SerializeField] public Text timerText, timerWinText;

    [HideInInspector] public bool isRestarted = false;
    float timer = 3.4f;

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
    }

    void nextLvl()
    {
        GameManager.gameStatus = GameManager.GameStatus.gameRunning;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        GameManager.gameStatus = GameManager.GameStatus.gameRunning;
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
