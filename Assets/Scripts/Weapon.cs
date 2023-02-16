using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bullets;
    Queue<GameObject> inGameBullets;

    void Start()
    {
        inGameBullets = new Queue<GameObject>();
        for(int i = 0; i < 10; i++)
            inGameBullets.Enqueue(bullets);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(inGameBullets.Dequeue(), transform.position, Quaternion.identity);
            inGameBullets.Enqueue(bullets);
        }
    }
}
