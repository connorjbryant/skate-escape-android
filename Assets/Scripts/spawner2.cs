using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner2 : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject obstacle2;
    public GameObject obstacle3;

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
            Instantiate(obstacle2, transform.position, Quaternion.identity);
            Instantiate(obstacle3, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
