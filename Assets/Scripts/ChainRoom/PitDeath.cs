using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDeath : MonoBehaviour
{
    [SerializeField] private GameObject DeathChecker;
    AudioSource bonesCrunch;
    bool hasDied;
    // Start is called before the first frame update
    void Start()
    {
        bonesCrunch = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasDied && !other.CompareTag("Bullet"))
        {
            hasDied = true;
            Debug.Log("PlayerFound");
            DeathChecker.SetActive(true);
            bonesCrunch.Play();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
       
    }
}
