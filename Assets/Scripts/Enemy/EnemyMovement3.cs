using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement3 : MonoBehaviour
{
    [SerializeField] float speed, jumpForce;
    Rigidbody2D rb;
    float timer = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                Debug.Log("1");
                Jump();
            }
            else if (timer >= 3.5)
            {
                Debug.Log("0");
                JumpCond();
            }
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    //void JumpRand()
    //{
    //    timer += Time.deltaTime;
    //    if (timer >= randTime)
    //    {
    //        rb.AddForce(Vector2.up * jumpForce);
    //        timer = 0;
    //        randTime = Random.Range(3,9);
    //    }
    //}

    void JumpCond()
    {
        LayerMask mask = LayerMask.GetMask(LayerMask.LayerToName(12));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20, mask);
        if (hit == true)
        {
            Jump();
        }
    }

    void Jump()
    {
        timer = 0;
        LayerMask groundMask = LayerMask.GetMask(LayerMask.LayerToName(0));
        RaycastHit2D grounded = Physics2D.Raycast(transform.position, Vector2.down, 1.19f, groundMask);
        if (grounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
