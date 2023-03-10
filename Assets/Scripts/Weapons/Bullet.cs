using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [HideInInspector] public int damage;

    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.layer == 11)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamageEnemy(damage);
        }
    }
}
