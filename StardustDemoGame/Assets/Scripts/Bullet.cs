using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{

    public GameObject bullet;


    public 
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
