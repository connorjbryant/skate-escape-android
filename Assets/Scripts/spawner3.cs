using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner3 : MonoBehaviour
{
    public GameObject obstacle;
    

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    //public float decreaseTime;
    //public float minTime = 0.65f;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            //int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstacle, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}

