using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorDrop : MonoBehaviour
{
    public GameObject EnemySpawnPoint;
    public Transform SpawnAbove;
    public GameObject Meteor;
    GameObject meteor2;
    CharacterController meteorController;
    float dropSpeed = 3f;
    bool MeteorActive = false;


    private void OnEnable()
    {
        Invoke("Spawn", 2.0f);
        Invoke("Death", 4f);
        //Destroy(EnemySpawnPoint, 4f);
        //ObjectPooler.Instance.ReturnMeteorToPool(gameObject, "Spawner");

    }
    private void Spawn()
    {
         
        meteor2 = Instantiate(Meteor, SpawnAbove.transform.position , EnemySpawnPoint.transform.rotation);
        MeteorActive = true;
        meteorController = meteor2.GetComponent<CharacterController>();
         
    }
    private void Update()
    {
        if (MeteorActive == true)
        {
           // meteorController.Move(Vector3.down * dropSpeed * Time.deltaTime);
        }
    }

    void Death()
    {

        ObjectPooler.Instance.ReturnMeteorToPool(gameObject, "Spawner");
       // Destroy(EnemySpawnPoint, 4f);
    }


}
