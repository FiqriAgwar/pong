using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    public PlayerControl player;

    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private DeathBallSpawner deathBallSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D anotherCollider){
        if(anotherCollider.name == "Ball"){
            player.IncrementScore();

            if(player.Score < gameManager.maxScore){
                anotherCollider.gameObject.SendMessage("RestartGame", 2f, SendMessageOptions.RequireReceiver);
            }
        }
        else if(anotherCollider.name == "DeathBall"){
            anotherCollider.gameObject.SendMessage("ResetDeathBall", 2f, SendMessageOptions.RequireReceiver);
            Destroy(anotherCollider.gameObject);
            deathBallSpawner.ResetTime();
        }
    }
}
