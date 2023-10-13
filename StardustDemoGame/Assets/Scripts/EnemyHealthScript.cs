using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealthScript : MonoBehaviour
{
    private int defaultHealth = 5;
    private int currentHealth;
    public ParticleSystem deathParticles;
    
   
    private void Start()
    {
        currentHealth = defaultHealth;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= 1;
            if(currentHealth <= 0)
            {
                GameManagerScript.instance.ScoreValue += 1000;
                GameManagerScript.instance.ScoreText.SetText("Score: " + GameManagerScript.instance.ScoreValue);
                RemoveObject();

            }
        }
    }

    void RemoveObject()
    { 
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }


}
