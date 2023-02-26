using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    [SerializeField] float speed;

    private void FixedUpdate()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
