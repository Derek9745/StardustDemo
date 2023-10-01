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


    private void Start()
    {
        Invoke("Spawn", 2.0f);
        Destroy(EnemySpawnPoint, 4f);
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
            meteorController.Move(Vector3.down * dropSpeed * Time.deltaTime);
        }
    }


}
