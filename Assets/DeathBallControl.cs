using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float initialForce;

    private GameManager gameManager;
    private GameObject player1;
    private GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetDeathBall();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        // Debug.Log(collision.gameObject.name);

        if(collision.gameObject.name == "Ball" || collision.gameObject.tag == "Enlarger"){
            return;
        }

        if(collision.gameObject == player1){
            gameManager.player2.setScore(gameManager.maxScore);
        }
        else if(collision.gameObject == player2){
            gameManager.player1.setScore(gameManager.maxScore);
        }

        ResetDeathBall();
    }

    void ResetDeathBall(){
        transform.position = Vector2.zero;
        this.rb.velocity = Vector2.zero;

        float angle = Random.Range(0f , 2f) * Mathf.PI;
        
        rb.AddForce(new Vector2(initialForce * Mathf.Cos(angle), initialForce * Mathf.Sin(angle)));
    }
}
