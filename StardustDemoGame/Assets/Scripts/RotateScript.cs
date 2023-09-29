using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public GameObject player;
    public float rotateSpeed = 5;

    void FixedUpdate()
    {
        player.transform.Rotate(0f,0f, rotateSpeed * Time.fixedDeltaTime, Space.Self);
    }
}
