using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    UIManager UM;

    private void Start()
    {
        UM = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "EndLevel")
        {
            GameManager.gameStatus = GameManager.GameStatus.gameEnd;
            UM.winScene.SetActive(true);
        }
        else
            GameManager.gameStatus = GameManager.GameStatus.gameFinish;
    }
}
