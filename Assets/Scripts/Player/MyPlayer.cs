using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPlayer : MonoBehaviour
{
    GameManager GM;

    [SerializeField] Image HPBar;
    [SerializeField] Text HPText;

    float HP;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        HP = GM.playerHP;
        HPBarFill();
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        HPBarFill();
        UpdateHP();
        if (HP <= 0)
        {
            gameObject.SetActive(false);
            GM.LoseGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 15)
        {
            HP = 100;
            HPBarFill();
            UpdateHP();
            collision.gameObject.SetActive(false);
        }
    }

    void HPBarFill()
    {
        HPBar.fillAmount = HP / 100;
        HPText.text = HP.ToString() + "%";
    }

    void UpdateHP()
    {
        GM.playerHP = HP;
    }
}