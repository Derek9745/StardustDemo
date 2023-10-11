using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject Meteor;
    Vector3 abovePos = new Vector3(0, 10, 0);
    private void Start()
    {
  
        InvokeRepeating("Spawn", 2f, 2f);
    }

    public void Spawn()
        {
            GameObject Spawner = ObjectPooler.Instance.SpawnMeteor("Spawner");
            Instantiate(Meteor, Spawner.transform.position +abovePos, Spawner.transform.rotation);
            Rigidbody wb = Meteor.GetComponent<Rigidbody>();
            wb.AddForce(Vector3.down, ForceMode.Impulse);


    }
    }




