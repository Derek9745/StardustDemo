using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerHealth : MonoBehaviour
{
    public int currentPlayerHealth;
    public int defaultPlayerHealth = 20;
    public GameObject player;
    public HealthBar healthBar;
    
    public void Start()
    {
        currentPlayerHealth = defaultPlayerHealth;
        healthBar.SetMaxHealth(defaultPlayerHealth);
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("You are taking Damage");
            TakeDamage();
        }

    }
     void TakeDamage()
    {
        currentPlayerHealth -= 5;
        healthBar.SetHealth(currentPlayerHealth);

        if (currentPlayerHealth <= 0)
        {
            GameManagerScript.instance.playerLives -= 1;
            var car = GameManagerScript.instance.livesText.text.ToCharArray();
            print(car.Last());

            if(GameManagerScript.instance.playerLives <= 0)
            {
                Destroy(player);
                //pause game and bring up lose screen.
            }
        }
    }

    
}
