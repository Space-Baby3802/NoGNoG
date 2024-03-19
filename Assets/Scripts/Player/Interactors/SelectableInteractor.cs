using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableInteractor : Interactor
{
    [Header("Interactions")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask interactionLayerMask;
    [SerializeField] private float interactionDistance;

    private RaycastHit hit;
    private ISelectable selection;

    public override void Interact()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, interactionDistance, interactionLayerMask))
        {
            Debug.Log("We hit " + hit.collider.name);
            Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);

            selection = hit.transform.GetComponent<ISelectable>();
            if (selection != null)
            {
                selection.OnHoverEnter();
                if (playerInput.activatePressed)
                {
                    selection.OnSelect();
                }
            }
        }

        if (hit.transform == null && selection != null)
        {
            selection.OnHoverExit();
            selection = null;
        }
    }

}
