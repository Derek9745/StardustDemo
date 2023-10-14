using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGrounded : MonoBehaviour
{
    public float amplitude = .2f;
    public float frequency = 1f;
    public bool isGrounded = false;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        Invoke("Check", 2f);
    }

    void Check()
    {
        isGrounded = true;
        posOffset = transform.position;
    }


    void FixedUpdate()
    {
        if (isGrounded == true)
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Cos(Time.fixedTime * Mathf.PI * frequency) * amplitude;
            transform.position = tempPos;
            transform.Rotate(1f, 5 * Time.deltaTime, 1f, Space.Self);
        }
    }
}
