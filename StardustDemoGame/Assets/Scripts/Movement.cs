using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private LayerMask whatIsGround; 

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
    public GameObject planet;
    public GameObject player;
    public float gravity = 9.8f;
    public Transform centerCube;

   
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
       
        Rotate();
        //SurfaceAlignment();
    }

    private void FixedUpdate()
    {
        //ApplyGravity();
        Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(move.x * 2, 0f, move.y * 2) * Time.deltaTime;// gets joystick input and places it into a vector 3 direction

        if (direction.magnitude >= 0.01f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
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

    private void ApplyGravity()
    {

        Vector3 diff = (planet.transform.position - player.transform.position);
        rb.AddForce(diff.normalized * gravity * rb.mass);
        player.transform.rotation = Quaternion.FromToRotation(Vector3.up, -diff) * transform.rotation;
    }

    private void SurfaceAlignment()
    {

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

