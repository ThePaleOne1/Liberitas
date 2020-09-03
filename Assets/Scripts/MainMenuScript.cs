using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public float LoadDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

	public void GameStart()
	{
        Invoke("LoadThing", LoadDelay);
	}

    private void LoadThing()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
	{
        Invoke("QuitThing", LoadDelay);

    }

    private void QuitThing()
    {
        Application.Quit();
        Debug.Log("quit game");
    }

}
