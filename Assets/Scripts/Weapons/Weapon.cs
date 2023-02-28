using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject charged;
    [SerializeField] Image chargedBar;

    [SerializeField] GameObject bullets, chargedBullet;
    Queue<GameObject> inGameBullets;

    float timerCharge;

    void Start()
    {
        inGameBullets = new Queue<GameObject>();
        for (int i = 0; i < 10; i++)
            inGameBullets.Enqueue(bullets);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        {
            timerCharge += Time.deltaTime;
            if (timerCharge >= 0.2f)
            {
                charged.gameObject.SetActive(true);
                chargedBar.fillAmount = timerCharge / 1.5f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && timerCharge >= 1.5f)
        {
            charged.gameObject.SetActive(false);
            ChargedShoot();
            timerCharge = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && timerCharge < 1.5f)
        {
            if (timerCharge >= 0.2f)
                charged.gameObject.SetActive(false);
            Shoot();
            timerCharge = 0;
        }
    }

    void ChargedShoot()
    {
        Bullet actualBullet = chargedBullet.GetComponent<Bullet>();
        actualBullet.damage = 40;
        Instantiate(actualBullet, transform.position, Quaternion.identity);
    }

    void Shoot()
    {
        Bullet actualBullet = inGameBullets.Dequeue().GetComponent<Bullet>();
        actualBullet.damage = 15;
        Instantiate(actualBullet, transform.position, Quaternion.identity);
        inGameBullets.Enqueue(bullets);
    }
}
