using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetScript : MonoBehaviour
{

    [SerializeField] private string sceneName;

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
