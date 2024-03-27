using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerText : MonoBehaviour
{
    [SerializeField] public TMP_Text AnswerNumber;
    public int currentNumber;
    [SerializeField] public int correctNumber;
    [SerializeField] private bool hasBeenAnswered = false;
    [SerializeField] AudioSource correctAnswer;
    [SerializeField] NewBehaviourScript sawWallScript;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        AnswerNumber.text = currentNumber.ToString();
        //CheckAnswer();
        if (currentNumber == correctNumber)
        {
            AnswerNumber.color = Color.green;
            Debug.Log("DING DING DING!");
            sawWallScript.questionSolved = 1;
            if (currentNumber == correctNumber && hasBeenAnswered == false)
            {
                correctAnswer.Play();
                hasBeenAnswered = true;
            }
        }
        if (currentNumber != correctNumber)
        {
            AnswerNumber.color = Color.red;
            hasBeenAnswered = false;
        }
    }

    private void CheckAnswer()
    {
        if (currentNumber == correctNumber)
        {
            AnswerNumber.color = Color.green;
            correctAnswer.Play();
        }
        else 
        {
            AnswerNumber.color= Color.red;
        }
    }
}
