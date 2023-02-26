using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    float horizontalMove, verticalMove;

    void FixedUpdate()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
            GetInput();
    }

    void GetInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        Move();
    }

    void Move()
    {
        transform.Translate(new Vector2(horizontalMove, verticalMove) * speed * Time.deltaTime, Space.World);
    }
}