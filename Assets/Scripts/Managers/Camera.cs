using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameManager GM;

    [SerializeField] float speed;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if(collision.gameObject.layer == 12)
            GM.LoseGame();
    }
}