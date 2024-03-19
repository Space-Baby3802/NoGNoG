using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    private PlayerInput playerInput;

    [Header("Player Movement")]
    [SerializeField] private float playerSpeed = 10;
    [SerializeField] private float sprintMultiplier;

    [Header("Ground Check")]
    [SerializeField] private float gravityStrength = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckDistance;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    public bool isOnGround { get; private set; }
    private float moveMultiplier = 1.0f;

    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
      
        playerInput = PlayerInput.GetInstance();

        //Hide Mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        MovePlayer();
    }

    private void GroundCheck()
    {
        isOnGround = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
    }

    private void MovePlayer()
    {
        moveMultiplier = playerInput.sprintHeld ? sprintMultiplier : 1.0f;

        // ? checks the boolean, what appears in front of the : is the result of the boolean being true, what's behind
        // the : is the result of the boolean being false.

        //Below is the same as above
        //    if (palyerInput.sprintHeld == true)
        //{ moveMultiplier = sprintMultiplier; }
        //    else
        //{ moveMultiplier = 1; }

        characterController.Move((transform.forward * playerInput.vertical + transform.right * playerInput.horizontal)
            * playerSpeed * moveMultiplier * Time.deltaTime);

        //Ground Check
        if (isOnGround && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravityStrength * Time.deltaTime;

        characterController.Move(playerVelocity * Time.deltaTime);
    }

    public void SetYVelocity(float value)
    {
        playerVelocity.y = value;
    }

    public float GetForwardSpeed()
    {
        return playerInput.vertical * playerSpeed * moveMultiplier;
    }
}
