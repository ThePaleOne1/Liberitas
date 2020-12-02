using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
	//public AudioSource aSource;
	public AudioSource startSource;
	public AudioSource movingSource;
	public AudioSource stopSource;
	//public AudioClip carsMove;

	public bool carsStart = true;
	//public bool carsEnd = false;

	public LevelChange lvlChange;

	// Start is called before the first frame update
	void Start()
    {
		startSource.loop = true;
		stopSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (lvlChange.CurrentLevel == 3 && carsStart == true)
		{
			startSource.Play();
			carsStart = false;
		}
		if (lvlChange.CurrentLevel != 3)
		{
			startSource.Stop();
			stopSource.Stop();
			carsStart = true;
		}
	}

	public void CarsMoving()
	{
		movingSource.Play();
		startSource.Stop();

	}

	public void CarsStop()
	{
		movingSource.Stop();
		stopSource.Play();
	}
}
