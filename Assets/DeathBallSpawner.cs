using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBallSpawner : MonoBehaviour
{
    public GameObject deathBall;
    public float timeBetweenSpawn;
    public float startingTime;

    private float time;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = startingTime;
        time = timeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime > 0){
            startTime -= Time.deltaTime;
            return;
        }

        if(time < 0){
            time = 0;
            SpawnDeathBall();
        }
        else if(time > 0){
            time -= Time.deltaTime;
        }
    }

    void SpawnDeathBall(){
        Instantiate(deathBall, transform.position, transform.rotation);
    }

    void RestartSpawner(){
        time = timeBetweenSpawn;
        startTime = startingTime;
    }

    public void ResetTime(){
        time = timeBetweenSpawn;
    }
}
