﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggleable : MonoBehaviour
{
    public bool IsActive = false;
    public bool Inverted = false;

    public Sprite ActiveObj;
    public Sprite InactiveObj;

    SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Inverted)
        {
            if (IsActive)
            {
                sp.sprite = ActiveObj;
            }
            else
            {
                sp.sprite = InactiveObj;
            }
        }
        else
        {
            if (IsActive)
            {
                sp.sprite = InactiveObj;
            }
            else
            {
                sp.sprite = ActiveObj;
            }
        }
        
    }
}