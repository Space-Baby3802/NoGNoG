using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{

    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private float checkRadius;

    public UnityEvent OnCubePlaced;
    public UnityEvent OnCubeRemoved;

    private void OnCollisionEnter(Collision collision)
    {
        //Check if cube is close to center
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, pickupLayerMask);

        Debug.Log(colliders.Length);

        foreach (Collider collider in colliders)
        {
            Debug.Log(collider.gameObject.name);
            //Unlock door if one or more cube(s) is on pressure plate

            if (collision.gameObject.CompareTag("PickCube"))
            {
                OnCubePlaced?.Invoke();
                break;
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickCube"))
        {
            OnCubeRemoved?.Invoke();
        }
    }
}
