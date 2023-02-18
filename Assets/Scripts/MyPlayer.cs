using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPlayer : MonoBehaviour
{
    GameManager GM;

    [SerializeField] Image HPBar;
    [SerializeField] Text HPText;

    [SerializeField] float maxHP;
    float HP;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        HP= maxHP;
        HPText.text = HP.ToString() + "%";
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        HPBarFill();
        HPText.text = HP.ToString() + "%";
        if(HP <= 0)
        {
            gameObject.SetActive(false);
            GM.EndGame();
        } 
    }

    void HPBarFill()
    {
        HPBar.fillAmount = HP / maxHP;
    }
}