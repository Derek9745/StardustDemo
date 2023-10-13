using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSplit : MonoBehaviour
{

    int downForce = 10;
    private CharacterController controller;


    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

       // Invoke("SpawnAliens", 10f);
    }

    private void Update()
    {
        controller.Move(downForce * Vector3.down * Time.deltaTime);
    }

    void SpawnAliens()
    {


    }
}
