using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [Header("Gun")]
    public MeshRenderer gunRenderer;
    public Color bulletGunColor;
    public Color rocketGunColor;

    [Header("Player Shoot")]
    [SerializeField] public ObjectPool bulletPool;
    [SerializeField] public ObjectPool rocketPool;





    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float shootVelocity;
    [SerializeField] public Transform shootPoint;
    [SerializeField] private PlayerMovementBehavior playerMovementBehavior;

    private float finalShootVelocity;
    private IShootStrategy currentShootStrategy;

    [SerializeField] private InputType inputType;
    public enum InputType
    {
        Primary,
        Secondary,
    }

    public Transform GetShootPoint()
    {
        return shootPoint;
    }

    public override void Interact()
    {
        if (currentShootStrategy == null)
        {
            currentShootStrategy = new BulletShootStrategy(this);
        }

        //Change strategy
        if (playerInput.weapon1pressed)
        {
            currentShootStrategy = new BulletShootStrategy(this);
        }

        if (playerInput.weapon2pressed)
        {
            currentShootStrategy = new RocketShootStrategy(this);
        }

        if (playerInput.primaryPressed && currentShootStrategy != null)
        {
            currentShootStrategy.Shoot();
        }
    }

    public float GetShootVelocity()
    {
        finalShootVelocity = playerMovementBehavior.GetForwardSpeed() + shootVelocity;
        return finalShootVelocity;
    }
}
