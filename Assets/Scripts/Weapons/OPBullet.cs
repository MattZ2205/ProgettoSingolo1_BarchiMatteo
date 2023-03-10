using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OPBullet : MonoBehaviour
{
    [SerializeField] GameObject miniBullet;
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ExplodeBullet();
        Destroy(gameObject);

        if (collision.gameObject.layer == 12)
        {
            MyPlayer player = collision.gameObject.GetComponent<MyPlayer>();
            player.TakeDamage(100);
        }
    }

    void ExplodeBullet()
    {
        EnemyBullet b = miniBullet.GetComponent<EnemyBullet>();
        b.dir = Vector2.up;
        b.damage = 10;
        Instantiate(b, transform.position, Quaternion.Euler(0, 0, -45));
        Instantiate(b, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(b, transform.position, Quaternion.Euler(0, 0, 45));
    }
}
