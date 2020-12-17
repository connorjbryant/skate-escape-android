using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pit : MonoBehaviour
{

    [SerializeField] private string sceneName;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PermanentUI.perm.health = PermanentUI.perm.health - 1;
            PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            if (PermanentUI.perm.health <= 0)
            {
                PermanentUI.perm.Reset();
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
