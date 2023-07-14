using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public GameObject player;

    void FixedUpdate()
    {
        player.transform.Rotate(0f, 5 * Time.fixedDeltaTime, 0f, Space.Self);
    }
}
