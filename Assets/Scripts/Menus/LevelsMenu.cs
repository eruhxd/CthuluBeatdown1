using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public string sceneName; 

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
