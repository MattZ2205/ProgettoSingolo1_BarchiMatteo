using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;

    float timer;

    void Update()
    {
        if(GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
        timer = 0;
    }
}