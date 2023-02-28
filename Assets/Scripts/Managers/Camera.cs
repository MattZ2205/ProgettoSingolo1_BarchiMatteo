using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    GameManager GM;

    [SerializeField] Image completeBar;

    [SerializeField] float speed;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        FillCompleteBar();
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if(collision.gameObject.layer == 12)
            GM.LoseGame();
    }

    void FillCompleteBar()
    {
        completeBar.fillAmount = transform.position.x / 82;
    }
}