using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float initialForce;

    private Vector2 trajectoryOrigin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RestartGame();

        trajectoryOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBall(){
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }

    void PushBall(){
        // float yRandomInitForce = Random.Range(-yInitialForce, yInitialForce);

        // float randomDirection = Random.Range(0,2);

        // if(randomDirection < 1f){
        //     rb.AddForce(new Vector2(-xInitialForce, yRandomInitForce));
        // }
        // else{
        //     rb.AddForce(new Vector2(xInitialForce, yRandomInitForce));
        // }

        float angle = Random.Range(0f , 2f) * Mathf.PI;
        
        rb.AddForce(new Vector2(initialForce * Mathf.Cos(angle), initialForce * Mathf.Sin(angle)));
    }

    void RestartGame(){
        ResetBall();
        Invoke("PushBall", 2);
    }

    private void OnCollisionExit2D(Collision2D collision){
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin{
        get{return trajectoryOrigin;}
    }

}
