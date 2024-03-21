using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeChecker : MonoBehaviour
{
    [SerializeField] private Animator bridgeMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveBridge()
    {
        bridgeMove.SetInteger("CorrectCubes", bridgeMove.GetInteger("CorrectCubes") + 1);
    }
}
