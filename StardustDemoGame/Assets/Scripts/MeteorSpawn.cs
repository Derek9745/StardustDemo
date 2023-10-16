using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject Meteor;
    Vector3 abovePos = new Vector3(0, 13, 0);
   

    private void Start()
    {
        //   Level currentLevel;
        //   currentLevel = Level.LEVEL_1;
        //    if (currentLevel == Level.LEVEL_1) { 
       // Spawn();
        // InvokeRepeating("Spawn", 5f, 1f);
        //Invoke("Spawn", 1f);
  //  }
    }

    public void Spawn()
    {
        //GameObject Spawner = ObjectPooler.Instance.SpawnMeteor("Spawner");
      //  Instantiate(Meteor, gameObject.transform.position + abovePos, gameObject.transform.rotation);
       // Rigidbody wb = Meteor.GetComponent<Rigidbody>();
       // wb.AddForce(Vector3.down, ForceMode.Impulse);
    }
   
}




