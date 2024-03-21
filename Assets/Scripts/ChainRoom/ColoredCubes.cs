using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredCubes : MonoBehaviour , ISelectable
{
    [SerializeField] private Transform attachPoint;
    [SerializeField] private GameObject placeCubeCanvas;
    [SerializeField] private GameObject playerHolding;
    [SerializeField] private ColoredAnswers coloredAnswers;
    [SerializeField] private BridgeChecker bridgeChecker;
    [SerializeField] private GameObject bridge;
    [SerializeField] private bool hasBeenAnswered = false;
    [SerializeField] private AudioSource bridgeHiss;

    public void OnHoverEnter()
    {
        placeCubeCanvas.SetActive(true);
        Debug.Log("Holding " + playerHolding.transform.Find("RedCube"));
        if (playerHolding.transform.childCount != 0 && playerHolding.transform.Find("RedCube") != null)
        {
            Debug.Log("We can place this cube");
            playerHolding.transform.Find("RedCube").transform.position = attachPoint.transform.position;
        }
        if (playerHolding.transform.childCount != 0 && playerHolding.transform.Find("YellowCube") != null)
        {
            Debug.Log("We can place this cube");
            playerHolding.transform.Find("YellowCube").transform.position = attachPoint.transform.position;
        }
        if (playerHolding.transform.childCount != 0 && playerHolding.transform.Find("OrangeCube") != null)
        {
            Debug.Log("We can place this cube");
            playerHolding.transform.Find("OrangeCube").transform.position = attachPoint.transform.position;
            
        }
        if (playerHolding.transform.childCount != 0 && playerHolding.transform.Find("BlueCube") != null)
        {
            Debug.Log("We can place this cube");
            playerHolding.transform.Find("BlueCube").transform.position = attachPoint.transform.position;
        }   
    }

    public void OnHoverExit()
    {
        placeCubeCanvas.SetActive(false);
    }

    public void OnSelect()
    {
            if (coloredAnswers.rightColor == true && !hasBeenAnswered) 
        { 
            bridge.transform.position = new Vector3(bridge.transform.position.x, bridge.transform.position.y, bridge.transform.position.z + 5.35f);
            hasBeenAnswered = true;
            bridgeHiss.Play();
            bridgeChecker.moveBridge();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
