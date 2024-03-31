using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BloodSplatterManager : MonoBehaviour
{
    public static float bloodCount;
    public static bool isDead;
    [SerializeField] private GameObject BloodScreen;
    [SerializeField] private GameObject BloodScreenOne;
    [SerializeField] private GameObject BloodScreenTwo;
    [SerializeField] public GameObject deathCanvas;
    public static float timeInFrontOfTurret;

    private void Update()
    {
        if (isDead)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }

        BloodScreen.GetComponent<Image>().color = new Color(255, 255, 255, BloodSplatterManager.bloodCount / 2);
        BloodScreenOne.GetComponent<Image>().color = new Color(255, 255, 255, BloodSplatterManager.bloodCount);
        BloodScreenTwo.GetComponent<Image>().color = new Color(255, 255, 255, BloodSplatterManager.bloodCount);
        bloodCount -= bloodCount*Time.deltaTime;

        if (timeInFrontOfTurret >= .5f && !isDead)
        {
            isDead = true;
            deathCanvas.SetActive(true);
        }

        if (timeInFrontOfTurret >= .51f)
        {
            timeInFrontOfTurret = 0.5f;
        }

    }
}
