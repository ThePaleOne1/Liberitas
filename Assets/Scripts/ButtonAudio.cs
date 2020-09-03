using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    AudioSource aSource;
    Button button;

    public AudioClip Hovered;
    public AudioClip Clicked;
    public AudioClip ClickRelease;

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        button = GetComponent<Button>();
    }

    public void PlayHover()
    {
        aSource.PlayOneShot(Hovered);
    }

    public void Playclicked()
    {
        aSource.PlayOneShot(Clicked);
    }

    public void PlayClickRelease()
    {
        aSource.PlayOneShot(ClickRelease);
    }
}
