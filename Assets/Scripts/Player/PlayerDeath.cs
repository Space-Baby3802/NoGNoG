using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] Camera deathCam;
    [SerializeField] Animator IDBurnAnim;
    [SerializeField] Animator camPanAnim;
    [SerializeField] AudioSource fireBurn;
    [SerializeField] ParticleSystem fireBurnParticles;
    [SerializeField] GameObject deathCanvas;
    [SerializeField] GameObject healthCanvas;
    [SerializeField] GameObject crosshairCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverTime()
    {
        playerCam.enabled = false;
        deathCanvas.SetActive(false);
        healthCanvas.SetActive(false);
        crosshairCanvas.SetActive(false);
        deathCam.enabled = true;
        IDBurnAnim.SetTrigger("CharacterDied");
        camPanAnim.SetTrigger("CharacterDiedCamera");
        fireBurn.Play();
        fireBurnParticles.Play();
    }
}
