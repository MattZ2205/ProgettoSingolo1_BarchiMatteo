using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject startMenu, tutorialScene;

    public void Play()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void Tutorial()
    {
        startMenu.SetActive(false);
        tutorialScene.SetActive(true);
    }

    public void Back()
    {
        tutorialScene.SetActive(false);
        startMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
