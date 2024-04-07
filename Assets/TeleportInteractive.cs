using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInteractive : MonoBehaviour , ISelectable
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform TeleportPoint;

    private Vector3 TeleportPosition;

    private void Start()
    {
        TeleportPosition = new Vector3(TeleportPoint.transform.position.x, TeleportPoint.transform.position.y, TeleportPoint.transform.position.z);
    }
    public void OnHoverEnter()
    {
        Debug.Log("Looking at door");
        Player.transform.position = TeleportPosition;
    }

    public void OnHoverExit()
    {
        Debug.Log("Not anymore");
    }

    public void OnSelect()
    {
        Debug.Log("teleport time");
        Player.transform.position = TeleportPosition;
    }
}
