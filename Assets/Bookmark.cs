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

    bool hasActivated = false;

    public void ActivateTab()
    {
        bookmarkMat.SetTexture("_MainTex", Activated);
        hasActivated = true;
    }

    public void DeactivateTab()
    {
        bookmarkMat.SetTexture("_MainTex", Deactivated);
    }

    private void Update()
    {
        if (hasActivated)
        {
            hasActivated = false;

            if (ActivationParticles != null)
            {
                Instantiate(ActivationParticles, ParticleSpawner.transform.position, ParticleSpawner.transform.rotation);
            }
        }
    }
}
