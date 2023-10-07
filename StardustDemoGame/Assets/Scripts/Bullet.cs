using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            if (collision.gameObject.tag != "Player")
            {
                ObjectPooler.Instance.ReturnToPool(gameObject, "Bullet");
            }
        }

    }



}
