using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadStartMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void LoadGameScene(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
    
    public void QuitGame(){
        Application.Quit();
    }
}
