using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class IDTableScript : MonoBehaviour , ISelectable 
{
    [SerializeField] private GameObject TextCanvas;
    [SerializeField] private TMP_Text WagerText;
    [SerializeField] private GameObject IDSet;

    [SerializeField] private Animator TableControl;

    [SerializeField] private BigDoorScript bigdoorscript;

    private void Start()
    {
        RaiseTable();
    }
    public void RaiseTable()
    {
        TableControl.SetTrigger("CutsceneOver");
    }

    public void LowerTable()
    {
        TableControl.SetTrigger("LifeWagered");
    }
    public void OnHoverEnter()
    {
        TextCanvas.SetActive(true);
    }

    public void OnHoverExit()
    {
        TextCanvas.SetActive(false);
    }

    public void OnSelect()
    {
        IDSet.SetActive(true);
        LowerTable();
        bigdoorscript.OpenDoor();
    }



}
