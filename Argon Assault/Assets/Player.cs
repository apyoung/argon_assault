using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    //InputActions
    PlayerInputActions inputActions;

    //Move
    Vector2 movementInput;

    //FireDirection
    Vector2 lookPosition;


    private Vector2 moveAxis;
    float speed = 2f;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.PlayerControls.Enable();
        inputActions.PlayerControls.Move.performed += HandleMove;
        inputActions.PlayerControls.Fire.performed += HandleFire;
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        
        moveAxis = context.ReadValue<Vector2>();
        Debug.Log($"Move Axis {moveAxis}");
    }

    private void HandleFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }

    private void OnDisable()
    {
        inputActions.PlayerControls.Disable();
        inputActions.PlayerControls.Move.performed -= HandleMove;
        inputActions.PlayerControls.Fire.performed -= HandleFire;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            moveAxis.x * Time.deltaTime * speed,  
            moveAxis.y * Time.deltaTime * speed, 
            0);
    }
}
