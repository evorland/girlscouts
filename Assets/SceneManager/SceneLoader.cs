using System.Collections.Generic;  
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit() {
        Application.Quit();
    }
}