using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuButtonFunctions : MonoBehaviour
{
    public void returnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameManagerScript.instance.Canvas.SetActive(false);
        GameManagerScript.instance.Pause();
    
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManagerScript.instance.Pause();
        GameManagerScript.instance.playerLives = 3;
        GameManagerScript.instance.livesText.SetText("X " + GameManagerScript.instance.playerLives);
        GameManagerScript.instance.ScoreValue = 0;
        GameManagerScript.instance.ScoreText.SetText("Score: " + GameManagerScript.instance.ScoreValue);
    }

    public void continueButton()
    {
        GameManagerScript.instance.Pause();
    }
  
}
