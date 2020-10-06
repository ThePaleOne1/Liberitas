using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingUI : MonoBehaviour
{
	public Animator UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void StartAnimation()
	{
		UI.SetBool("startPressed", true);
	}

	public void OptionsPressed()
	{
		print("Still working, sadly");
	}
}
