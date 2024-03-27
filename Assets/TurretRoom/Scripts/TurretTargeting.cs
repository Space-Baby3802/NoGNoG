using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TurretTargeting : MonoBehaviour
{
    [SerializeField] private Transform rayShooter;
    [SerializeField] private LayerMask player;

    [SerializeField] private AudioSource turretActive;
    [SerializeField] private GameObject DeathCanvas;
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
                BloodSplatterManager.bloodCount = 1;
                BloodSplatterManager.bloodCount += BloodSplatterManager.bloodCount * 3 * Time.deltaTime;
                BloodSplatterManager.timeInFrontOfTurret += Time.deltaTime;
                Debug.Log("In front of turret for: " + BloodSplatterManager.timeInFrontOfTurret);
            }
            else
            {
              Debug.Log(hit.collider.gameObject.layer);
            }
        }
        if (BloodSplatterManager.bloodCount >= 255)
        {
            BloodSplatterManager.isDead = true;
        }
    }


}
