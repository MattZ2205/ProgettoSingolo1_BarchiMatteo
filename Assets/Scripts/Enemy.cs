using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Image HPBar;

    float sinCenterY;
    [SerializeField] float enemySpeed, HP;

    private void Start()
    {
        sinCenterY = 0;
    }

    void Update()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        {
            transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
            Vector2 pos = transform.position;
            float sin = Mathf.Sin(pos.x);
            pos.y = sinCenterY + sin * 3f;
            transform.position = pos;
        }
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
            Destroy(gameObject);
    }

    void HPBarFill()
    {
        HPBar.fillAmount = HP / 100;
    }
}