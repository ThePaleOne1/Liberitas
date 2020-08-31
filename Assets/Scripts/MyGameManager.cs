using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
