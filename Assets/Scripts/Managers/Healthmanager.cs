using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Healthmanager : MonoBehaviour
{
    [SerializeField] private RectTransform healthbar;
     float health = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.GetComponent<RectTransform>().localScale = new Vector3(health - BloodSplatterManager.timeInFrontOfTurret * 8, 0.35f, 0f);
    }
}

