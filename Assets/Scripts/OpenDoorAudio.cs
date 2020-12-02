using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAudio : MonoBehaviour
{

	public AudioSource aSource;
	public AudioClip doorOpen;

	public bool doorOpening = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	public void TriggerAudio()
	{
		aSource.PlayOneShot(doorOpen);
	}
}
