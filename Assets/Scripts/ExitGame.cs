using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
}
