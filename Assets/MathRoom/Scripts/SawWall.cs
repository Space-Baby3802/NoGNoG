using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject sawWall;
    public float questionSolved = 0.5f;
    bool isSawActive;
    int sawNumber = 0;
    [SerializeField] AudioSource[] saws;
    [SerializeField] float wallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (questionSolved == 0)
        {
            sawWall.transform.position = new Vector3(sawWall.transform.position.x, sawWall.transform.position.y, sawWall.transform.position.z - 1 * wallSpeed * Time.deltaTime);
        }
        if (questionSolved == 1)
        {
            sawWall.transform.position = new Vector3(sawWall.transform.position.x, sawWall.transform.position.y + 1 * wallSpeed * Time.deltaTime, sawWall.transform.position.z);
            sawNumber--;
            saws[sawNumber].Pause();
            Debug.Log("Lifting the wall");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isSawActive)
        {
            saws[sawNumber].Play();
            sawNumber++;
            if(sawNumber == saws.Length)
            {
                isSawActive = true;
                questionSolved = 0;
            }
        }
    }

    public void test()
    {

    }
}
