using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerText : MonoBehaviour
{
    [SerializeField] public TMP_Text AnswerNumber;
    public int currentNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnswerNumber.text = currentNumber.ToString();

        AnswerNumber.color = Color.green;
    }

}
