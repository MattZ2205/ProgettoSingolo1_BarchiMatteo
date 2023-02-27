using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform upLimit, downLimit;

    float timer;
    [SerializeField] float timeToSpawn;

    void Update()
    {
        if(GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(downLimit.position.y, upLimit.position.y), 0), Quaternion.identity);
        timer = 0;
    }
}