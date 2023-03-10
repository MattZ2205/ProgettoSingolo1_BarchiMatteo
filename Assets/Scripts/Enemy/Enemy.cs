using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Image HPBar;
    [SerializeField] float maxHP;
    float HP;

    private void Start()
    {
        HP = maxHP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            MyPlayer pl = collision.gameObject.GetComponent<MyPlayer>();
            pl.TakeDamage(50);
        }
    }

    public void TakeDamageEnemy(int damage)
    {
        HP -= damage;
        HPBarFill();
        if (HP <= 0)
        {
            Destroy(gameObject);
            GameManager.score += 100;
        }
    }

    void HPBarFill()
    {
        HPBar.fillAmount = HP / maxHP;
    }
}