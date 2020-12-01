using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayStuff : MonoBehaviour
{
    AudioSource aSource;

    public LevelChange lvlChange;

    public DirectionalLight directionalLight;

    public Animator animToEffect;
    public string BoolName;

    public AstarPath astarPath;

    public LanternTracker lanternTracker;
    public int[] lightsToToggle;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void CanWalkTrue()
    {
        FindObjectOfType<RayCastOnClick>().PlayerCanWalk = true;
    }

    public void CanWalkFalse()
    {
        FindObjectOfType<RayCastOnClick>().PlayerCanWalk = false;
        lvlChange.walkTarget.transform.position = lvlChange.StartingPosPerLevel[lvlChange.CurrentLevel - 1].transform.position;
    }



    public void PlayAudioSound(AudioClip sound)
    {
        aSource.PlayOneShot(sound);
    }

    public void ToggleAnimBool()
    {
        animToEffect.SetBool(BoolName, !animToEffect.GetBool(BoolName));
    }

    public void RescanPath()
    {
        astarPath.Scan();
    }

    public void ToggleLanterns()
    {
        lanternTracker.ToggleLight(lightsToToggle);
    }
}
