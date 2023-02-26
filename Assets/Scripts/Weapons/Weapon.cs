using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bullets;
    Queue<GameObject> inGameBullets;

    [SerializeField] bool isEnemyWeapon;
    float timerShoot;

    void Start()
    {
        inGameBullets = new Queue<GameObject>();
        for (int i = 0; i < 10; i++)
            inGameBullets.Enqueue(bullets);
    }

    void Update()
    {
        if (isEnemyWeapon && GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        {
            timerShoot += Time.deltaTime;
            if (timerShoot >= 1.5f)
            {
                GameObject actualBullet = inGameBullets.Dequeue();
                Bullet enemyBullet = actualBullet.GetComponent<Bullet>();
                enemyBullet.isEnemy = true;
                Instantiate(actualBullet, transform.position, Quaternion.identity);
                inGameBullets.Enqueue(bullets);
                timerShoot = 0;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space) && GameManager.gameStatus == GameManager.GameStatus.gameRunning && !isEnemyWeapon)
        {
            GameObject actualBullet = inGameBullets.Dequeue();
            Bullet playerBullet = actualBullet.GetComponent<Bullet>();
            playerBullet.isEnemy = false;
            Instantiate(actualBullet, transform.position, Quaternion.identity);
            inGameBullets.Enqueue(bullets);
        }
    }
}
