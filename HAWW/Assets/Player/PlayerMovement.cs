using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement")]
    public float moveSpeed;
    public float airDrag;
    public float groundDrag;

    [Header ("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update(){
    // jump 
        jumpPlayer();

    //ground checking
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        myInput();
    
    // apply drag on air 
        if(!grounded){
            rb.drag = airDrag;
        }

    // apply drag on ground
        if(grounded){
            rb.drag = groundDrag;
        }
        
    }

    void FixedUpdate() {
        movePlayer();    
    }

    void myInput(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void movePlayer(){
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    void jumpPlayer(){
        if(Input.GetKeyDown(KeyCode.Space) && grounded){
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            grounded = false;
        }
    }
}
