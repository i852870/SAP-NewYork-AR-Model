using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;

public class CentralParkText : InteractionReceiver
{
    public GameObject textObjectState;
    public GameObject boatObj;
    private TextMesh txt;

    void Start()
    {
        txt = textObjectState.GetComponentInChildren<TextMesh>();
        boatObj = GameObject.Find("Boats_Empire");
        Debug.Log(boatObj);
    }

    protected override void FocusEnter(GameObject obj, PointerSpecificEventData eventData)
    {
        txt.text = obj.name;

    }

    protected override void FocusExit(GameObject obj, PointerSpecificEventData eventData)
    {
        txt.text = " ";
    }
}
