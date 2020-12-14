using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    Animator anim;

	public AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            anim.SetBool("IsTriggered", !anim.GetBool("IsTriggered"));
			aSource.Stop();
			aSource.Play();
        }
    }

	
    public void Continue()
    {
        anim.SetBool("IsTriggered", false);
    }
}
