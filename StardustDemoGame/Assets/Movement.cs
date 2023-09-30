using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    PlayerControls playercontrols;
    public CharacterController controller;
    Vector2 move;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public Transform cam;
    public GameObject image;
    void Awake()
    {
        playercontrols = new PlayerControls();
        playercontrols.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        playercontrols.Player.Move.canceled += ctx => move = Vector2.zero;
        playercontrols.Player.StartButton.performed += ctx => GameManagerScript.instance.Pause();

        
    }

    void Update()
    {
        Move();
        if (image.activeInHierarchy == true)
        {
            Time.timeScale = 0f;
        }
    }

    private void Move()
    {
        Vector3 direction = new Vector3(move.x * 2, 0f, move.y * 2) * Time.deltaTime;

        if (direction.magnitude >= 0.01f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            Mathf.Clamp(moveDir.y, .5f, .5f);
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }
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

