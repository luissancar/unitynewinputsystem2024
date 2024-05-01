
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    private float fuerzaSalto = 200f;
    private float  velocidad = 10f;

    private PlayerInput _playerInput;
    private Vector2 input;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        input = _playerInput.actions["Move"].ReadValue<Vector2>();
        Debug.Log(input);
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(input.x,0,input.y)*velocidad);
    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            rb.AddForce(Vector3.up*fuerzaSalto);
            Debug.Log("Salto");
        }
        Debug.Log(callbackContext.phase);
    }
}
