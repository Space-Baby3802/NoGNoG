using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform TeleportPoint;
    private float teleportTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Debug.Log($"Teleport timer is at {teleportTimer}");
            teleportTimer += Time.deltaTime;
            if (teleportTimer >= 1)
            {
                Debug.Log("Teleport time");
                player.transform.position = new Vector3(TeleportPoint.transform.position.x, TeleportPoint.transform.position.y, TeleportPoint.transform.position.z);
                teleportTimer = 1;
            }
        }
        else
        {
            Debug.Log(player.transform.position);
        }
    }
}
