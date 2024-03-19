using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorScript : MonoBehaviour
{
    private Animator DoorAnim;

    private float doorTimer = 0;

    [SerializeField] private float waitTime = 2f;

    private void Awake()
    {
        DoorAnim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorTimer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        doorTimer += Time.deltaTime;
        if (doorTimer >= waitTime)
        {
            doorTimer = waitTime;
            DoorAnim.SetBool("isDoorOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorAnim.SetBool("isDoorOpen", false);
        }
    }
}
