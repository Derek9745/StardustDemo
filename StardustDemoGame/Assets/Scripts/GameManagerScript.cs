using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int playerLives = 3;
    public static GameManagerScript instance = null;
    public SceneInfo sceneInfo;
    public GameObject image;
    public GameObject continueText;
    public TextMeshProUGUI ScoreText;
    public GameObject Canvas;
    public int ScoreValue = 0;
    public TextMeshProUGUI livesText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
            Debug.Log("Warning: there is already another instance of this object!");
        }
        sceneInfo.isPaused = false;
        image.SetActive(false);
        continueText.SetActive(true);
        Canvas.SetActive(true);
  
    }

    

     public void Pause()
    {
        if (sceneInfo.isPaused == false)
        {
            Time.timeScale = 0f;
            image.SetActive(true);
            sceneInfo.isPaused = true;
        }
        else if(sceneInfo.isPaused == true)
        {
            Time.timeScale = 1f;
            image.SetActive(false);
            sceneInfo.isPaused = false;
        }
        
    }


}
