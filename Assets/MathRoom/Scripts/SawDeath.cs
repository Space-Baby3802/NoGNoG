using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDeath : MonoBehaviour
{
    [SerializeField] GameObject deathCanvas;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !isDead)
        {
            BloodSplatterManager.timeInFrontOfTurret += Time.deltaTime;
        }
    }
}
