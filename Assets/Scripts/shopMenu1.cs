using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopMenu1 : MonoBehaviour
{

    public Button button;

    public void buySpeed()
    {
        if (PermanentUI.perm.coins == 10)
        {
            //Destroy(collision.gameObject);
            //GetComponent<SpriteRenderer>().color = Color.black;
            PermanentUI.perm.jumpForce += 5;
            PermanentUI.perm.coins -= 10;
            PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
            //PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            GetComponent<Image>().color = Color.green;
        }
        else if (PermanentUI.perm.coins < 10)
        {
            Debug.Log("broke bitch");
            //PermanentUI.perm.health -= 1;
            PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            //GetComponent<SpriteRenderer>().color = Color.black;
            PermanentUI.perm.coins -= 10;
            PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
            PermanentUI.perm.jumpForce += 5;
            //PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            GetComponent<SpriteRenderer>().color = Color.green;
            GetComponent<Image>().color = Color.green;
        }
    }

}

