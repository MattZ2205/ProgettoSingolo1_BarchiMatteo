using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    MyPlayer pl;

    [SerializeField] GameObject bullets;
    Queue<GameObject> inGameBullets;

    [SerializeField] bool isEnergyWeapon, isOPWeapon;
    [SerializeField] float timeToShoot;
    float timerShoot;

    void Start()
    {
        pl = FindObjectOfType<MyPlayer>();
        inGameBullets = new Queue<GameObject>();
        for (int i = 0; i < 5; i++)
            inGameBullets.Enqueue(bullets);
    }

    void Update()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        {
            timerShoot += Time.deltaTime;
            if (timerShoot >= timeToShoot)
            {
                if (isOPWeapon)
                {
                    Instantiate(inGameBullets.Dequeue(), transform.position, Quaternion.identity);
                    inGameBullets.Enqueue(bullets);
                    timerShoot = 0;
                }
                else
                {
                    if (isEnergyWeapon)
                        Shoot((pl.transform.position - transform.position).normalized, 10, true);
                    else
                        Shoot(Vector2.left, 20, true);
                }
            }
        }
    }

    void Shoot(Vector2 direction, int damage, bool isEnemy)
    {
        GameObject actualBullet = inGameBullets.Dequeue();
        EnemyBullet shootBullet = actualBullet.GetComponent<EnemyBullet>();
        shootBullet.dir = direction;
        shootBullet.damage = damage;
        Instantiate(actualBullet, transform.position, Quaternion.identity);
        inGameBullets.Enqueue(bullets);
        timerShoot = 0;
    }
}
