using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySphere : MonoBehaviour
{
    Enemy en;

    [SerializeField] float rotationSpeed;

    private void Start()
    {
        en = FindObjectOfType<Enemy>();
    }

    void Update()
    {
        transform.RotateAround(en.transform.position, Vector3.forward, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 12)
        {
            MyPlayer p = collision.GetComponent<MyPlayer>();
            p.TakeDamage(100);
        }
    }
}
