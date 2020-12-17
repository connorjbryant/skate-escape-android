using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorShower2 : MonoBehaviour
{
    public GameObject policeman_0;
    public float speed = 100f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-50.0f, 50.0f), -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private IEnumerator Destroy()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Destroy());
    }
}
