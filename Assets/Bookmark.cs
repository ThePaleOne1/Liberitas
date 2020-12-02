using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookmark : MonoBehaviour
{
    public Material bookmarkMat;

    public Texture Activated;
    public Texture Deactivated;

    public void ActivateTab()
    {
        bookmarkMat.SetTexture("_MainTex", Activated);
    }

    public void DeactivateTab()
    {
        bookmarkMat.SetTexture("_MainTex", Deactivated);
    }


}
