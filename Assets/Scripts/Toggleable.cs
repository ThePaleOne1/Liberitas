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
                bookmark.enabled = true;
                bookmark.ActivateTab();
               
            }
            else
            {
                bookmark.DeactivateTab();
                bookmark.enabled = false;
            }
        }
        else
        {
            if (IsActive)
            {
                bookmark.enabled = true;
                bookmark.ActivateTab();
            }
            else
            {
                bookmark.DeactivateTab();
                bookmark.enabled = false;
            }
        }

    }
}
