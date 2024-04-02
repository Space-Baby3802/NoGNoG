using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] AudioSource MusicOne;
    [SerializeField] AudioSource MusicTwo;
    [SerializeField] AudioSource VictoryFare;
    [SerializeField] SceneChanger sceneSwap;
    bool inRoom = false;
    [SerializeField] private float victoryCountdown;
    // Start is called before the first frame update
    void Start()
    {
        sceneSwap = GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRoom)
        {
            victoryCountdown -= Time.deltaTime;
            if (victoryCountdown <= 0)
            {
                sceneSwap.ChangeScene();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MusicOne.Pause();
            MusicTwo.Pause();
            VictoryFare.Play();
            inRoom = true;
        }
        else Debug.Log("Not Player");
    }
}
