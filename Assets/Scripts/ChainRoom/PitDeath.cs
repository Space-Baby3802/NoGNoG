using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDeath : MonoBehaviour
{
    [SerializeField] private GameObject DeathChecker;
    AudioSource bonesCrunch;
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
        DeathChecker.SetActive(true);
        bonesCrunch.Play();
    }
}
