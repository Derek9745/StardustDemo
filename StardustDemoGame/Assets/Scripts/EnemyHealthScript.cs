using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
