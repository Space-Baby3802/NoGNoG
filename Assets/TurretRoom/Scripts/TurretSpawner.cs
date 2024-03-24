using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Turret;
    [SerializeField] private Transform TurretSpawn;
    private float turretTimer;
    private int turretCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        turretTimer += Time.deltaTime;
        if (turretTimer >= 7f && turretCount < 10)
        {
            SpawnTurret();
            turretCount++;
            turretTimer = 0;
        }
    }

    private void SpawnTurret()
    {
        Turret = Instantiate(Turret, TurretSpawn.position, TurretSpawn.rotation);
    }
}
