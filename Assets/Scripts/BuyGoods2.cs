using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BuyGoods2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shop1")
        {
            if (PermanentUI.perm.coins == 10)
            {
                //Destroy(collision.gameObject);
                GetComponent<SpriteRenderer>().color = Color.black;
                PermanentUI.perm.jumpForce += 5;
                PermanentUI.perm.coins -= 10;
                PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
                //PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            }
            else if (PermanentUI.perm.coins < 10)
            {
                Debug.Log("broke bitch");
                //PermanentUI.perm.health -= 1;
                PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.black;
                PermanentUI.perm.coins -= 10;
                PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
                PermanentUI.perm.jumpForce += 5;
                //PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            }
        }
    }
}
