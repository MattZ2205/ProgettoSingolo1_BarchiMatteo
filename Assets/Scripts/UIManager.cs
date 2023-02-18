using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu, endGameScene;
    [SerializeField] public Text timerText;

    public bool isRestarted = false;
    float timer = 3.4f;

    private void Update()
    {
        if (isRestarted)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.Round(timer).ToString();
            if(timer <= 0.6f)
                Restart();
        }
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
}
