using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharkScript : MonoBehaviour
{
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
