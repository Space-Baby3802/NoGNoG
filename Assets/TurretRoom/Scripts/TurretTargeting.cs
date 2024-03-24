using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    [SerializeField] private Transform rayShooter;
    [SerializeField] private LayerMask player;

    [SerializeField] private AudioSource turretActive;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(rayShooter.position, Vector3.left, out RaycastHit hit, 1000f))
        {
            if (hit.collider.gameObject.layer == 8)
            {
                Debug.DrawRay(rayShooter.position, Vector3.left, Color.cyan);
                Debug.Log("I can see you!");
                turretActive.Play();
            }
            else
            {
              Debug.Log(hit.collider.gameObject.layer);
            }
        }
    }


}
