using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StairMovement : MonoBehaviour
{
    [SerializeField] GameObject nextStep;
    [SerializeField] bool hasMoved;
    [SerializeField] bool startTimer = false;
    float moveTimer;
    [SerializeField] float moveTimerCap;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            MoveRight();
            moveTimer += Time.deltaTime;

        }
    }

    public void MoveRight()
    {
        if (!hasMoved)
        {
            nextStep.transform.position = new Vector3(nextStep.transform.position.x + 8.75f * Time.deltaTime * 8, nextStep.transform.position.y, nextStep.transform.position.z);
            if (moveTimer >= moveTimerCap)
            {
                hasMoved = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        startTimer = true;
    }

}
