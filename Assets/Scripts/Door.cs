using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Door : MonoBehaviour
{
   
    private Animator DoorAnim;

    private float doorTimer = 0;

    [SerializeField] private Renderer doorRenderer;
    [SerializeField] private Color defaultMat;
    [SerializeField] private Color changedMat;

    [SerializeField]private float waitTime = 2f;

    private bool isLocked = true;

    private void Awake()
    {
        DoorAnim = GetComponent<Animator>();
        if (doorRenderer != null)
        {
            defaultMat = doorRenderer.material.color;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isLocked && other.CompareTag("Player"))
        {
            doorTimer = 0;
           doorRenderer.material.color = changedMat;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isLocked) { return; }
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
            doorRenderer.material.color = defaultMat;
        }
    }

    public void LockDoor()
    {
        isLocked = true;
    }

    public void UnlockDoor() 
    {
        isLocked = false; 
    }
}
