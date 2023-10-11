using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{

    public float moveForce = 25;
    public Transform spawnPoint;
    public void OnEnable()
    {

       InvokeRepeating("Spawn", .0f, .1f);
       
    }
    public void Spawn()
    {
        GameObject bullet = ObjectPooler.Instance.SpawnFromPool("Bullet");
        Rigidbody wb = bullet.GetComponent<Rigidbody>();
        wb.AddForce(spawnPoint.forward * moveForce, ForceMode.Impulse);
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
        
    }



}


