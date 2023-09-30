using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int playerLives = 3;
    public TextMeshProUGUI livesText;
    public static GameManagerScript instance;
    public GameObject image;
    public bool GameIsPaused;

   
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
        GameIsPaused = false;
        image.SetActive(false);
    }

    private void Update()
    {
        if (playerLives <= 0)
        {
            image.SetActive(true);
            Pause();
            
        }
    }

     public void Pause()
    {
        if (GameIsPaused == false)
        {
            Time.timeScale = 0f;
            image.SetActive(true);
            GameIsPaused = true;
        }
        else if(GameIsPaused == true)
        {
            Time.timeScale = 1f;
            image.SetActive(false);
            GameIsPaused = false;
        }
        
    }


}
