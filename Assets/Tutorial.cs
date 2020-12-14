using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : Interactable
{
    public GameObject NextStep;

    public override void Interact()
    {
        if(NextStep != null) NextStep.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
