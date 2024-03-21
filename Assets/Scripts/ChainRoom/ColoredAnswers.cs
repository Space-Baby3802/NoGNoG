using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredAnswers : MonoBehaviour
{
    [SerializeField] private string ColorNeeded;
    [SerializeField] private GameObject bridge;
    [SerializeField] public bool rightColor = false;
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
        if (other.CompareTag(ColorNeeded))
        {
            rightColor = true;
            Debug.Log("Aw yeah baby!");
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        rightColor = false;
    }
}
