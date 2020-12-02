using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternAudio : MonoBehaviour
{
	public AudioSource aSource;
	public AudioClip lanternOn;
	public AudioClip lanternOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void PlayAudioOn()
	{
		aSource.PlayOneShot(lanternOn);
	}

	public void PlayAudioOff()
	{
		aSource.PlayOneShot(lanternOff);
	}
}
