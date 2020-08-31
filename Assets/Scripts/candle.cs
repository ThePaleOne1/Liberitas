using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candle : Interactable
{
    public Toggleable[] ToggleObjects;
    public GameObject flame;
    public bool isLit = false;

    
    
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if (isLit)
        {
            flame.SetActive(true);
        }
        else
        {
            flame.SetActive(false);
        }
    }



    //public void SetTabActive()
    //{
    //    ActivateDeactivate(true);
    //}

    //public void SetTabInactive()
    //{
    //    ActivateDeactivate(false);
    //}

    void ActivateToggleables(bool setActive)
    {
        foreach(Toggleable toggle in ToggleObjects)
        {
            toggle.IsActive = setActive;
        }
    }

    public override void Interact()
    {
        print("player has interacted with a candle");

        if (MyGameManager.GM.IsHoldingFlame)
        {
            if (isLit)      //is holding flame and candle is already lit
            {
                print("candle is already lit");
            }
            else            //is holding flame cand candle is not lit
            {
                print("Lit the candle");
                ActivateToggleables(true);
                isLit = true;
                MyGameManager.GM.IsHoldingFlame = false;
            }
            return;
        }
        else
        {
            if (isLit)      //is not holding flame and candle is lit
            {
                print("you took the fire from the candle");
                ActivateToggleables(false);
                isLit = false;
                MyGameManager.GM.IsHoldingFlame = true; 
            }
            else            //is not holdign flame and candle is not lit
            {
                print("you dont have any fire to give the candle");
            }
            return;
        }
    }
}
