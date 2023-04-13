using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
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
        SceneManager.LoadScene("Level1");
    }

    public void BackToMainHandler()
    {
        SceneManager.LoadScene("Start");
    }
}
