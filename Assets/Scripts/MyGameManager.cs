using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// THIS IS A STATIC OBJECT TO STORE GLOBAL VARIABLES!!! 
/// Basically Variables that you have to access in several scripts that you dont wanna have to
/// create new public variables for every single time, you can just create the public variable once
/// here, then put the object in through the inspect on the "game manager" EGO.
/// then you can reference it in any script by typing e.g. MyGameManager.IsHoldingFlame = false;
/// </summary>
public class MyGameManager : MonoBehaviour
{
    public PostProcessVolume PPV;
    public bool IsHoldingFlame;
    public GameObject Player;
    public GameObject InteractCenter;
	public bool DoorOneOpen;


	public static MyGameManager GM;

    void Awake()
    {
        if (GM != null)
            GameObject.Destroy(GM);
        else
            GM = this;

        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (IsHoldingFlame)
        {
            PPV.enabled = false;
        }
        else
        {
            PPV.enabled = true;
        }
    }

}
