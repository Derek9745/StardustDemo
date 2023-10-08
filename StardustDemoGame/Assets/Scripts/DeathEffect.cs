using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    public ParticleSystem deathParticles;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            RemoveObject();
        }
    }

    void RemoveObject()
    {
        
    }
}
