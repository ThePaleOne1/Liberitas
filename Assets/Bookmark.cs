using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookmark : MonoBehaviour
{
    public Material bookmarkMat;

    public Texture Activated;
    public Texture Deactivated;

    public GameObject ActivationParticles;
    public GameObject ParticleSpawner;

   

    public void ActivateTab()
    {
        bookmarkMat.SetTexture("_MainTex", Activated);
        
    }

    public void DeactivateTab()
    {
        bookmarkMat.SetTexture("_MainTex", Deactivated);
    }


    private void OnEnable()
    {
        if (ActivationParticles != null)
        {
            Instantiate(ActivationParticles, ParticleSpawner.transform);
        }
    }
}
