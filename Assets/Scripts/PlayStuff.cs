using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStuff : MonoBehaviour
{
    AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioSound(AudioClip sound)
    {
        aSource.PlayOneShot(sound);
    }
}
