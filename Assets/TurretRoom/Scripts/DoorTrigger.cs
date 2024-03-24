using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Animator doorAnim;
    [SerializeField] AudioSource doorAudio;
    [SerializeField] string doorAnimTrigger;

    private bool doorOpen=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!doorOpen)
        {
            doorAnim.SetTrigger(doorAnimTrigger);
            doorAudio.Play();
            doorOpen = true;
        }
        else
        {
            return;
        }
    }
}
