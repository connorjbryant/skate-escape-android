using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject policeman_0;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(policemanWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(policeman_0) as GameObject;
        a.transform.position = new Vector2(10, 200);
    }

    IEnumerator policemanWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
        
    }
}
