using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractor : Interactor
{
    [Header("Pickup Interaction")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private float pickupDistance;
    [SerializeField] private Transform attachTransform;

    private RaycastHit hit;
    private iPickable pickable;

    private bool isPicked = false;

    public override void Interact()
    {
        //Cast a ray
        if (Physics.Raycast(GetRayHit(), out hit, pickupDistance, pickupLayerMask))
        {
            if (playerInput.activatePressed && !isPicked)
            {
                pickable = hit.transform.GetComponent<iPickable>();
                if (pickable == null)
                {
                    return;
                }

                pickable.OnPicked(attachTransform);
                isPicked = true;
                return;
            }
        }

        //Drop Item
        if (playerInput.activatePressed && isPicked && pickable != null)
        {
            pickable.OnDropped();
            isPicked = false;
        }
    }

    private Ray GetRayHit()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        return ray;
    }
}
