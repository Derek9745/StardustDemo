using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform spawnPoint;
    
    public float moveForce = 25f;
    GameObject bullet;
    Rigidbody rb;

 
 

    void Awake()
    {

       rb = bullet.GetComponent<Rigidbody>();
    }

    void Update()
    {

      
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * moveForce, ForceMode.Impulse);
    }



}


