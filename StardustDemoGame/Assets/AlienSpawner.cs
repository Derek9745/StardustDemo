using UnityEngine;

public class AlienSpawner : MonoBehaviour
{

    public GameObject Alien;
    public ParticleSystem deathParticles;
   void OnEnable()
    {
        Invoke("SpawnCreatures", 15f);
    }

    public void SpawnCreatures()
    {

        Instantiate(Alien, gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(deathParticles, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);

    }


}
