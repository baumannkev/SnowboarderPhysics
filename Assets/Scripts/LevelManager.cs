using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public void NextLevel()
    {
        Invoke("NextLevelHandler", 1.5f);
    }
    public void RestartLevel()
    {
        Invoke("RestartHandler", 1.5f);
    }

    public void BackHome()
    {
        Invoke("BackToMainHandler", 1.5f);
    }

    public void RestartHandler()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    public void BackToMainHandler()
    {
        SceneManager.LoadScene("Start");
    }

    public void NextLevelHandler()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            // Optional: Go back to the first scene if at the last scene
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
    
}
