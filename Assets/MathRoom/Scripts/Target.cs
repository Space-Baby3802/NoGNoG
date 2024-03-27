using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int counterNumber;
    [SerializeField] AnswerText answerScreenScript;
    [SerializeField] AudioSource ding;
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
        if (!CompareTag("Player"))
        {
            Debug.Log("Hit by a bullet");
            answerScreenScript.currentNumber += counterNumber;
            ding.Play();
        }
        else
        {
            Debug.Log("Hit by anything else");
        }
    }
}
