using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    public bool isEnemy;

    void Update()
    {
        if (isEnemy)
            transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.layer == 11)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamageEnemy(20);
        }

        if (collision.gameObject.layer == 12)
        {
            MyPlayer player = collision.gameObject.GetComponent<MyPlayer>();
            player.TakeDamage(20);
        }
    }
}
