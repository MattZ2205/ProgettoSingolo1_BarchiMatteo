using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float sinCenterY;
    [SerializeField] float enemySpeed, HP;

    private void Start()
    {
        sinCenterY = 0;
    }

    void Update()
    {
        transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x);
        pos.y = sinCenterY + sin * 3f;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
            Destroy(collision.gameObject);
    }

    public void takeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
            Destroy(gameObject);
    }
}