using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{

    public GameObject bullet;

    private void Start()
    {
        Destroy(gameObject, 3);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ForceField")
        {
            Destroy(gameObject);
        }

    }





}
