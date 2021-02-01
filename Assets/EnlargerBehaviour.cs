using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargerBehaviour : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player1;
    private GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Ball"){
            float velocityX = col.gameObject.GetComponent<Rigidbody2D>().velocity.x;
            
            if(velocityX > 0){
                player1.transform.localScale = new Vector3(player1.transform.localScale.x, player1.transform.localScale.y + 1.5f, player1.transform.localScale.z);
            }
            else{
                player2.transform.localScale = new Vector3(player2.transform.localScale.x, player2.transform.localScale.y + 1.5f, player2.transform.localScale.z);
            }

            Destroy(gameObject);
        }
    }
}
