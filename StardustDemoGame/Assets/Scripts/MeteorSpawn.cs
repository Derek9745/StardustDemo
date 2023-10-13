using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject Meteor;
    Vector3 abovePos = new Vector3(0, 10, 0);
    enum Level { LEVEL_1, LEVEL_2, LEVEL_3, LEVEL_4, LEVEL_5 }

    private void Start()
    {
        Level currentLevel;
        currentLevel = Level.LEVEL_1;
        if (currentLevel == Level.LEVEL_1) { 

        InvokeRepeating("Spawn", 5f, 1f);

    }
    }

    public void Spawn()
    {
        GameObject Spawner = ObjectPooler.Instance.SpawnMeteor("Spawner");
        Instantiate(Meteor, Spawner.transform.position + abovePos, Spawner.transform.rotation);
        Rigidbody wb = Meteor.GetComponent<Rigidbody>();
        wb.AddForce(Vector3.down, ForceMode.Impulse);
    }
   
}




