using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pause : MonoBehaviour
{
    public bool IsPaused;

    public GameObject PauseMenu;

    // Use this for initialization
    void Start()
    {

    }

    public void Paused()
    {
        if (IsPaused)
        {
            PermanentUI.perm.PauseMenu.SetActive(true);
            //PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PermanentUI.perm.PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }


        if (Input.GetMouseButtonDown(0))
        {
            PermanentUI.perm.IsPaused = !PermanentUI.perm.IsPaused;
            //IsPaused = !IsPaused;
        }

        PermanentUI.perm.IsPaused = !PermanentUI.perm.IsPaused;
    }

    public void unPause()
    {
        PermanentUI.perm.PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

}
