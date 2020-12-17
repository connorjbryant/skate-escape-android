using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGoods4 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shop2")
        {
            if (PermanentUI.perm.coins == 10)
            {
                //Destroy(collision.gameObject);
                GetComponent<SpriteRenderer>().color = Color.cyan;
                PermanentUI.perm.ScaleToTarget(new Vector3(0.2f, 1f, 1f), 1f);
                //PermanentUI.perm.colorChange();
                PermanentUI.perm.speed += 5;
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
                GetComponent<SpriteRenderer>().color = Color.cyan;
                //PermanentUI.perm.ScaleToTarget(new Vector3(2.5f, 2.5f, 1f), 1f);
                PermanentUI.perm.coins -= 10;
                //PermanentUI.perm.colorChange();
                PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
                PermanentUI.perm.speed += 5;
                //PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            }
        }
    }
}
