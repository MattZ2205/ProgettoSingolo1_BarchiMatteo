using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float sinCenterY;
    [SerializeField] float enemySpeed;

    private void Start()
    {
        sinCenterY = transform.position.y;
    }

    void FixedUpdate()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        {
            transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);
            Vector2 pos = transform.position;
            float sin = Mathf.Sin(pos.x);
            pos.y = sinCenterY + sin;
            transform.position = pos;
        }
    }
}
