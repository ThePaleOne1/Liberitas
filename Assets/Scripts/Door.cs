using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{

	public bool isOpen = false;

	//audio if we have door open/close audio
	AudioSource aSource;
	public AudioClip doorOpen;

	public Animator anim;


	// Start is called before the first frame update
	void Start()
    {
		aSource = GetComponent<AudioSource>();
		//anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		if (anim.GetBool("IsTriggered") == true)
		{
			MyGameManager.GM.DoorOneOpen = true;
		}
		else
		{
			MyGameManager.GM.DoorOneOpen = false;
		}
    }

	public override void Interact()
	{
		if (MyGameManager.GM.DoorOneOpen)
		{
			print("Door opened");
			return;
		}
		else
		{
			print("Door is still shut");
			return;
		}
	}

}
