using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    Color originalColor;
    Renderer rend;
    float duration = .3f;
    public ParticleSystem deathParticles;
  
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(HitFlash());
        }

        if(collision.gameObject.tag == "Meteor")
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("Meteors hitting each other" + deathParticles.transform.position);
        }     
            
    }

 
    public IEnumerator HitFlash()
    {
        rend.material.color = Color.white;
        yield return new WaitForSeconds(duration);
        rend.material.color = originalColor;
    }
}
