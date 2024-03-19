using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCube : MonoBehaviour, iPickable
{

    FixedJoint joint;
    Rigidbody cubeRb;

    private void Start()
    {
        cubeRb = GetComponent<Rigidbody>();
    }
    public void OnDropped()
    {
        transform.SetParent(null);

        cubeRb.isKinematic = false;
        cubeRb.useGravity = true;
    }

    public void OnPicked(Transform attachTransform)
    {
        transform.position = attachTransform.position;
        transform.rotation = attachTransform.rotation;
        transform.SetParent(attachTransform);

        cubeRb.isKinematic = true;
        cubeRb.useGravity = false;

    }
}
