using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargerSpawner : MonoBehaviour
{
    public GameObject enlarger;
    public float startingTime;
    public float timeBetweenMin;
    public float timeBetWeenMax;
    public float xBound;
    public float yBound;

    private float startTime;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        startTime = startingTime;
        time = timeBetweenMin;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime > 0){
            startTime -= Time.deltaTime;
            return;
        }      

        GameObject[] count = GameObject.FindGameObjectsWithTag("Enlarger");
        if(count.Length > 0){
            return;
        }

        if(time > 0){
            time -= Time.deltaTime;
            return;
        }
        else{
            Vector3 position = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound), 0);
            Instantiate(enlarger, position, Quaternion.identity);
            time = Random.Range(timeBetweenMin, timeBetWeenMax);
        }
    }
}
