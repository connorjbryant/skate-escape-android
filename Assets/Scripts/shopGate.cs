using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopGate : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public GameObject yourbutton;

    public void DisableButton()
    {
        if (PermanentUI.perm.coins <= 0)
        {
            yourbutton.SetActive(false);

        }
        else
        {
            yourbutton.SetActive(true);
            SceneManager.LoadScene(sceneName);
        }

    }

    
}
