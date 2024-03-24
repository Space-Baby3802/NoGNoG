using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    bool isSawActive;
    int sawNumber = 0;
    [SerializeField] AudioSource[] saws;
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
        if (!isSawActive)
        {
            saws[sawNumber].Play();
            sawNumber++;
            if(sawNumber == saws.Length)
            {
                isSawActive = true;
            }
        }
    }
}
