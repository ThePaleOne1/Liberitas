using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePrompt : MonoBehaviour
{
    public LevelChange lvlChange;
    public GameObject Button;

    public Animator Anim;

    private void Update()
    {
        if(lvlChange.CurrentLevel == 1)
        {
            Button.SetActive(false);
        }
        else
        {
            Button.SetActive(true);
        }
    }

    public void OpenPauseMenu()
    {
        Button.SetActive(false);
        Anim.SetBool("IsTriggered", true);
    }

    public void SetPromptActive()
    {
        Button.SetActive(true);
    }
}
