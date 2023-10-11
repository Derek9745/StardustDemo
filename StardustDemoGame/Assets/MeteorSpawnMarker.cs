using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnMarker : MonoBehaviour
{
   
    void OnEnable()
    {
        Invoke("Death", 4f);
    }

    void Death()
    {
        ObjectPooler.Instance.ReturnMeteorToPool(gameObject, "Spawner");
    }
 
}
