using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWeapon : MonoBehaviour
{
    [SerializeField] GameObject bullets;
    Queue<GameObject> inGameBullets;

    float timerShoot;

    void Start()
    {
        inGameBullets = new Queue<GameObject>();
        for (int i = 0; i < 10; i++)
            inGameBullets.Enqueue(bullets);
    }

    void Update()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        {
            timerShoot += Time.deltaTime;
            if (timerShoot >= 1.5f)
            {
                Instantiate(inGameBullets.Dequeue(), transform.position, Quaternion.identity);
                inGameBullets.Enqueue(bullets);
                timerShoot = 0;
            }

        }
    }
}