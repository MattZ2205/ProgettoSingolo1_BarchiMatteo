using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [HideInInspector] public Vector2 dir;
    [HideInInspector] public int damage;

    void Update()
    {
        transform.Translate(dir * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.layer == 12)
        {
            MyPlayer player = collision.gameObject.GetComponent<MyPlayer>();
            player.TakeDamage(damage);
        }
    }
}
