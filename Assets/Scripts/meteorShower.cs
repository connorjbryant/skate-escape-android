using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorShower : MonoBehaviour
{
    public GameObject policeman_0;
    public float speed = 100f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public GameObject explosion2;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-50.0f, 50.0f), -speed);
        GameObject expl2 = Instantiate(explosion2, gameObject.transform.position, Quaternion.identity);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Destroy(expl2, 1); // delete the explosion after 3 seconds
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Destroy());
    }
}
