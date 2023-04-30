using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 50;
    [SerializeField] private float sprintSpeed = 150;
    [SerializeField] private float crouchSpeed = 25;
    [SerializeField] private Transform Orientation;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 direction;
    private Rigidbody rb;
    [SerializeField] private float groundDrag = 5;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance = 0.4f;
    private bool isGrounded;

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCd;
    [SerializeField] private float airMultiplier;
    private bool readyJump;

    [Header("Sprinting")]
    [SerializeField] private float sprintCd;
    private bool readySprint;

    [Header("Crouching")]
    [SerializeField] private float crouchCd;
    [SerializeField] private float crouchHeight = 0.5f;
    private bool readyCrouch;
    private bool isCrouched;

    // Start is called before the first frame update
    void Start()
    {
        readyJump = true;
        readySprint = true;
        readyCrouch = true;
        isCrouched = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        speedControl();
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void getInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    if (Input.GetKey(KeyCode.LeftShift) && isGrounded && readySprint) 
    {
        readySprint = false;
        moveSpeed = sprintSpeed;
        InvokeRepeating(nameof(resetSprint), sprintCd, sprintCd);
    }

    if (Input.GetKeyDown(KeyCode.C) && isGrounded && readyCrouch) {
        readyCrouch = false;
        crouch();
        Invoke(nameof(resetCrouch), crouchCd);
    }

    if (Input.GetKey(KeyCode.Space) && isGrounded && readyJump)
    {
        readyJump = false;
        jump();
        Invoke(nameof(resetJump), jumpCd);
    }
    }


    private void movePlayer()
    {
        if (isCrouched)
    {
            direction = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
            rb.AddForce(direction.normalized * crouchSpeed, ForceMode.Force);
    }
        else
    {
            direction = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
            if (isGrounded)
        {
                rb.AddForce(direction.normalized * moveSpeed, ForceMode.Force);
        }
            else if (!isGrounded)
        {
                rb.AddForce(direction.normalized * moveSpeed * airMultiplier, ForceMode.Force);
        }
    }
}


    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        readyJump = true;
    }

    private void resetCrouch() {
        readyCrouch = true;
    }

    private void crouch() {
        if (isCrouched) {
            isCrouched = false;
            transform.localScale = new Vector3(1,1,1);
        }
        else {
            isCrouched = true;
            transform.localScale = new Vector3(1, crouchHeight, 1);
        }        
    }

    private void resetSprint() {
        readySprint = true;
        moveSpeed = 50;
    }

    public void canMove(bool value)
    {
        if (value)
        {
            moveSpeed = 50;

        }
        else
        {
            moveSpeed = 0;
        }
    }
}
