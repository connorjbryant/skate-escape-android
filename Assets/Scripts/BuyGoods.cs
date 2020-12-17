using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyGoods : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PermanentUI.perm.coins == 5)
            {
                PermanentUI.perm.health += 1;
                PermanentUI.perm.coins -= 5;
                PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
                PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            }
            else if (PermanentUI.perm.coins < 5)
            {
                Debug.Log("broke bitch");
                //PermanentUI.perm.health -= 1;
                PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            }
            else
            {
                PermanentUI.perm.health += 1;
                PermanentUI.perm.coins -= 5;
                PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
                PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            }
        }
    }
}

