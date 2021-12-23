using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MysteryShip : MonoBehaviour
{
    private Vector3 _direction = Vector2.right;
    public int speed = 5;
    public int life = 100;
    public int shiptotal;
    ScoreController player;
    private int score;
    public GameObject shipSound;
    public GameObject destructionsound;


    void Start()
    {
        //Instantiate(shipSound);
        player = GameObject.Find("ScoreTotal").GetComponent<ScoreController>();

    }
    void Update()
    {
        this.transform.position += _direction * speed* Time.deltaTime;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
            
        if(_direction == Vector3.right && this.transform.position.x >= (rightEdge.x - 1.0f))
        {
                TurnArround();
        }else if(_direction == Vector3.left && this.transform.position.x <= (leftEdge.x + 1.0f))
        {
            TurnArround();
        }
    }

    private void TurnArround()
    {
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        this.transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        shipSound.SetActive(false);
        Instantiate(destructionsound);
        score = 10;
        player.SetScore(score);
        this.gameObject.SetActive(false);
    }
}
