using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuButtonFunctions : MonoBehaviour
{
    public void returnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameManagerScript.instance.Pause();
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManagerScript.instance.Pause();
    }

    public void continueButton()
    {
        GameManagerScript.instance.Pause();
    }
}
