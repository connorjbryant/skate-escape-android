using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartButton : MonoBehaviour
{
    

    [SerializeField] private string sceneName;

    public void changeScene2()
    {
        SceneManager.LoadScene(sceneName);
    }
}
