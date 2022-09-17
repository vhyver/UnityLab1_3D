using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [NonSerialized] public float rotationSpeed = 90f;
    private float gravity = -20f;
    public float jumpHeight = 15f;

    public CharacterController characterController;
    Vector3 movementVector;
    Vector3 rotationVector;

    void Start()
    {
        
    }

    
    void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            movementVector = transform.forward * movementSpeed * vInput;
            rotationVector = transform.up * rotationSpeed * hInput;
            if (Input.GetButtonDown("Jump"))
            {
                movementVector.y = jumpHeight;
            }
        }

        movementVector.y += gravity * Time.deltaTime;
        characterController.Move(movementVector * Time.deltaTime);
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
