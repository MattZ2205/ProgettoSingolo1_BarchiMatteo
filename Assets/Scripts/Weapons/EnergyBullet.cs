using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBullet : MonoBehaviour
{
    MyPlayer pl;

    [SerializeField] float speed;
    Vector3 dir;

    private void Start()
    {
        pl = FindObjectOfType<MyPlayer>();
        dir = pl.transform.position - transform.position;
    }

    private void Update()
    {
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.layer == 12)
        {
            MyPlayer player = collision.gameObject.GetComponent<MyPlayer>();
            player.TakeDamage(10);
        }
    }
}
