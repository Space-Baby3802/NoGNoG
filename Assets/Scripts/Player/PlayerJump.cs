using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementBehavior))]
public class PlayerJump : Interactor
{

    [Header("Player Jump")]
    [SerializeField] private float jumpVelocity;

    private PlayerMovementBehavior playerMovementBehavior;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementBehavior = GetComponent<PlayerMovementBehavior>();
    }

    public override void Interact()
    {
        if (playerInput.jumpPressed && playerMovementBehavior.isOnGround)
        {
            playerMovementBehavior.SetYVelocity(jumpVelocity);
        }
    }
}
