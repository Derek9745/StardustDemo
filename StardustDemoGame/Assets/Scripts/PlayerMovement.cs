using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    PlayerControls playercontrols;
    Vector2 move;


    public float speed = 6f;
 
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    public Transform cam;
    public CharacterController controller;
  

    private void Awake()
    {

        playercontrols = new PlayerControls();
        playercontrols.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        playercontrols.Player.Move.canceled += ctx => move = Vector2.zero;
    }


    private void Move()
    {
        Vector3 direction = new Vector3(move.x, 0f, move.y ) * Time.deltaTime;
      
        if (direction.magnitude >= 0.01f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }
    }

    private void FixedUpdate()
    {
        Move();
    }



    private void OnEnable()
    {
        playercontrols.Player.Move.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Player.Move.Disable();
    }



}
