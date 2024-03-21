using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainTry : MonoBehaviour , iPickable

{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform chain;
    private bool isPicked = false;
    public void OnDropped()
    {
        isPicked = false;
        player.transform.SetParent(null);
        player.transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void OnPicked(Transform attachTransform)
    {
        isPicked = true;
        player.transform.SetParent(this.transform);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPicked)
        {
            player.transform.position = chain.position;
        }
    }
}
