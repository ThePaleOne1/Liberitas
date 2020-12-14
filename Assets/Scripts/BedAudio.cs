using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedAudio : MonoBehaviour
{
	public AudioSource aSource;
	public AudioClip bedsheetAudio;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void PlayAudio()
	{
		aSource.PlayOneShot(bedsheetAudio);
	}
}
