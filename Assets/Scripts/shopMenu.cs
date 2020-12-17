using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class shopMenu : MonoBehaviour
{

    public Button button;

    public void buyLives()
    {
        if (PermanentUI.perm.coins == 5)
        {
            PermanentUI.perm.health += 1;
            PermanentUI.perm.coins -= 5;
            PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
            PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            GetComponent<Image>().color = Color.green;
        }
        else if (PermanentUI.perm.coins < 5)
        {
            Debug.Log("broke bitch");
            //PermanentUI.perm.health -= 1;
            PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            PermanentUI.perm.health += 1;
            PermanentUI.perm.coins -= 5;
            PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
            PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            GetComponent<Image>().color = Color.green;
        }
    }
}

