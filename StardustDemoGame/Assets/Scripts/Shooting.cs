using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public Rigidbody rb;
    public float moveForce = 25f;
    public float timeToFire = 3f;

    void Start()
    {
       
    }



    private void FixedUpdate()
    {


        
    } 
    

    void spawnBullet()
    {
       Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
       rb.AddForce(transform.forward * moveForce, ForceMode.Impulse);

    }


}


