using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Rigidbody rbody;
    public GameObject bullet;

     void Awake()
    {
        
    }

    [SerializeField] private float timeToSelfDestruct = 5f;
    void Update()
    {

    }

    private void OnEnable()
    {
       StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
       yield return new WaitForSeconds(timeToSelfDestruct);
        Destroy(bullet);
   }



    private void OnCollisionEnter(Collision collision)
    {   
     
          Destroy(bullet);
    }





}
