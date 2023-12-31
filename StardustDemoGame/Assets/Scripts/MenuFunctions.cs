using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public GameObject CreditText;


    private void Start()
    {

        CreditText.SetActive(false);
    }


    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }

    public void showCredits()
    {
        CreditText.SetActive(true);
    }
}
