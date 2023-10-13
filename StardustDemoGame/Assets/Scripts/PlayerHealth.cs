using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int currentPlayerHealth;
    public int defaultPlayerHealth = 5;
    public int currentShieldHealth;
    public int defaultShieldHealth = 5;
    public GameObject player;
    public HealthBar healthBar;
    public HealthBar shieldBar;

    PlayerHealth playerHealth;

   


    public void Start()
    {
        currentPlayerHealth = defaultPlayerHealth;
        healthBar.SetMaxHealth(defaultPlayerHealth);

        currentShieldHealth = defaultShieldHealth;
        shieldBar.SetMaxHealth(defaultShieldHealth);
        GameManagerScript.instance.livesText.SetText( "X " + GameManagerScript.instance.playerLives);
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            TakeDamage(1);
        }

    }
     void TakeDamage(int damage)
    {
      
        currentPlayerHealth -= damage;
        healthBar.SetHealth(currentPlayerHealth);

        if (currentPlayerHealth <= 0)
        {
            GameManagerScript.instance.playerLives -= 1;
            GameManagerScript.instance.livesText.SetText("X " + GameManagerScript.instance.playerLives);
            currentPlayerHealth = defaultPlayerHealth;
            healthBar.SetHealth(defaultPlayerHealth);

            if (GameManagerScript.instance.playerLives < 0)
            {
              
                GameManagerScript.instance.livesText.SetText("X " + 0);
                GameManagerScript.instance.Pause();
                GameManagerScript.instance.continueText.SetActive(false);
            }
        }
    }

   

}
