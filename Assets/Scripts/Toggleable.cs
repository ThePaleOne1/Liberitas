using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggleable : MonoBehaviour
{
    public bool IsActive = false;
    public bool Inverted = false;


    public Bookmark bookmark;
    


    void Update()
    {
        if (!Inverted)
        {
            if (IsActive)
            {
                bookmark.ActivateTab();
            }
            else
            {
                bookmark.DeactivateTab();
            }
        }
        else
        {
            if (IsActive)
            {
                bookmark.ActivateTab();
            }
            else
            {
                bookmark.DeactivateTab();
            }
        }
    }
}
