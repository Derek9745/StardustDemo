using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

    }


    void Update()
    {
        CheckOutOfBounds();
    }

    void CheckOutOfBounds()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1 || viewPos.z < 0)
        {
            ObjectPooler.Instance.ReturnToPool(gameObject, "Bullet");
        }
    }





private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag != "Bullet")
        {
            if (collision.gameObject.tag != "Player")
            {
                if (collision.gameObject.tag != "ForceField")
                {
                    ObjectPooler.Instance.ReturnToPool(gameObject, "Bullet");
                }
            }
        }
    }
}
