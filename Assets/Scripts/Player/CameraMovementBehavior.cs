using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovementBehavior : MonoBehaviour
{
    private PlayerInput playerInput;

    [Header("Player Camera Movement")]
    [SerializeField] private float turnSpeed = 10;
    [SerializeField] private bool isInverted;

    private float camXRotation;

    private void Awake()
    {
        playerInput = PlayerInput.GetInstance();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        //Camera up/down movement
        camXRotation += Time.deltaTime * playerInput.mouseY * turnSpeed * (isInverted ? 1 : -1);
        camXRotation = Mathf.Clamp(camXRotation, -50.0f, 65f);
        transform.localRotation = Quaternion.Euler(camXRotation, 0, 0);
    }
}
