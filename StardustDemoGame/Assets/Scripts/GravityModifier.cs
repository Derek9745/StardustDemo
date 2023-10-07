using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    public Transform player;
    public Transform planet;
    int acceleration = 3;
    float gravity = 9.8f;
    public Rigidbody rb;
   
  
     
    void FixedUpdate()
    {
        //Vector3 diff = (planet.transform.position - player.transform.position);
        //rb.AddForce(diff.normalized * gravity * rb.mass);
        //player.transform.rotation = Quaternion.FromToRotation(Vector3.up, -diff) * transform.rotation;
        
    }

    
}
