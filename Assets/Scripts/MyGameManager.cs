using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS IS A STATIC OBJECT TO STORE GLOBAL VARIABLES!!! 
/// Basically Variables that you have to access in several scripts that you dont wanna have to
/// create new public variables for every single time, you can just create the public variable once
/// here, then put the object in through the inspect on the "game manager" EGO.
/// then you can reference it in any script by typing e.g. MyGameManager.IsHoldingFlame = false;
/// </summary>
public class MyGameManager : MonoBehaviour
{
    public bool IsHoldingFlame;
    public GameObject Player;
    public GameObject InteractCenter;

    public static MyGameManager GM;

    void Awake()
    {
        if (GM != null)
            GameObject.Destroy(GM);
        else
            GM = this;

        DontDestroyOnLoad(this);
    }


}
