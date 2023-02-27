using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement3 : MonoBehaviour
{
    [SerializeField] float speed, jumpForce;
    Rigidbody2D rb;

    float timer, randTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randTime = Random.Range(3, 9);
    }

    void Update()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        {
            JumpRand();
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void JumpRand()
    {
        timer += Time.deltaTime;
        if (timer >= randTime)
        {
            rb.AddForce(Vector2.up * jumpForce);
            timer = 0;
            randTime = Random.Range(3,9);
        }
    }
}
