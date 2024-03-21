using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    [SerializeField] private Transform rayShooter;
    [SerializeField] private LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(rayShooter.position, Vector3.left, 1000f, player))
        {
            Debug.DrawRay(rayShooter.position, Vector3.left, Color.cyan);
            Debug.Log("I can see you!");
        }
        
    }


}
