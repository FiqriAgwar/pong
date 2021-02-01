using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public float speed = 10f;
    public float yBound = 9f;
    private Rigidbody2D rb;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        if(Input.GetKey(upButton)){
            velocity.y = speed;
        }
        else if(Input.GetKey(downButton)){
            velocity.y = -speed;
        }
        else{
            velocity.y = 0f;
        }

        rb.velocity = velocity;

        Vector3 position = transform.position;

        if(position.y > yBound){
            position.y = yBound;
        }
        else if(position.y < -yBound){
            position.y = -yBound;
        }

        transform.position = position;
    }

    public void IncrementScore(){
        score++;
    }

    public void ResetScore(){
        score = 0;
    }

    public int Score{
        get{return score;}
    }

    public void setScore(int inputScore){
        score = inputScore;
    }

    private ContactPoint2D lastContactPoint;
    
    public ContactPoint2D LastContactPoint{
        get{return lastContactPoint;}
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name.Equals("Ball")){
            lastContactPoint = collision.GetContact(0);
        }
    }
}
