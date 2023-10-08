using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    PlayerControls playercontrols;
    public Shooting shoot;
    public Rigidbody rb;
    Vector2 move;
    Vector2 rotation;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public Transform cam;
    public GameObject image;
    public Transform centerCube;
    public GameObject planet;
    public GameObject player;

    // Vector3 direction;
    //Vector3 adjustedDirection;
    void Awake()
    {
        playercontrols = new PlayerControls();
        playercontrols.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        playercontrols.Player.Move.canceled += ctx => move = Vector2.zero;
        playercontrols.Player.StartButton.performed += ctx => GameManagerScript.instance.Pause();
        playercontrols.Player.BulletFire.performed += ctx => rotation = ctx.ReadValue<Vector2>();
        playercontrols.Player.BulletFire.canceled += ctx => rotation = ctx.ReadValue<Vector2>();
    }

    void Update()
    {
        Move();
        Rotate();
       
    }

    private void Move()
    {
            Vector3 direction = new Vector3(move.x * 2, 0f, move.y * 2) * Time.deltaTime;// gets joystick input and places it into a vector 3 direction

            if (direction.magnitude >= 0.01f)
            {

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //rb.AddForce((planet.transform.position - player.transform.position).normalized * 10);
            //player.transform.rotation = Quaternion.LookRotation(planet.transform.position - player.transform.position, transform.up);

                 rb.MovePosition(rb.position + moveDir.normalized * speed * Time.deltaTime);



        }
    }

   




    private void Rotate()
    {
        Vector3 rotateDirection = new Vector3(rotation.x * 2, 0f, rotation.y * 2) * Time.deltaTime;

        if (rotateDirection.magnitude >= 0.01f)
        {
            float targetAngle = Mathf.Atan2(rotateDirection.x, rotateDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            centerCube.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);



        }
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
       // Gizmos.color = Color.red;
       // Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        //Vector3 updirection = transform.TransformDirection(Vector3.up) * 5;
       // Gizmos.DrawRay(transform.position, direction);
        //Gizmos.DrawRay(transform.position, updirection);
    }


    void OnEnable()
     {
         playercontrols.Player.Enable();
     }

     void OnDisable()
     {
         playercontrols.Player.Disable();
     }
 }

