using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    public Transform player;
    public Transform planet;
    public CharacterController controller;
    int acceleration = 3;
    float gravity = 9.8f;
    float vSpeed;
     
    void Update()
    {
       // transform position = planet.transform - player.transform;
        //vSpeed = gravity * Time.deltaTime;
        //controller.Move(position * vSpeed);
        //transform.rotation = Quaternion.LookRotation(planet.position - transform.position, transform.up);
    }
}
