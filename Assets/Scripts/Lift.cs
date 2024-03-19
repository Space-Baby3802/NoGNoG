using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{

    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isUp;
    [SerializeField] private bool isMoving;

    private Vector3 targetPosition;
    

    public void ToggleLift()
    {
        if (isMoving) { return; }
        if (isUp)
        {
            targetPosition = transform.localPosition - new Vector3 (0, moveDistance, 0);
            isUp = false;
        }
        else
        {
            targetPosition = transform.localPosition + new Vector3(0, moveDistance, 0);
            isUp=true; 
        }

        isMoving = true;
    }
    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    ToggleLift();
        //}
        if (isMoving)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, moveSpeed* Time.fixedDeltaTime);
        }
        if (Vector3.Distance(transform.localPosition, targetPosition) < 0.02f)
        {
            isMoving = false;
        }
    }
}
