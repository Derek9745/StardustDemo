using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
 
    public float moveForce = 25f;

    void Start()
    {
        InvokeRepeating("spawnBullet", 0f, .2f);
    }

    void spawnBullet()
    { 
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        Rigidbody wb = bullet.GetComponent<Rigidbody>();
        wb.AddForce(spawnPoint.forward * moveForce, ForceMode.Impulse);


    }


}


