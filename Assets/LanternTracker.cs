using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternTracker : MonoBehaviour
{

    
    public List<GameObject> AllLights;

    public int activeLights = 0;

    // Update is called once per frame
    private void Start()
    {
        foreach (GameObject light in AllLights)
        {
            if (light.activeSelf)
            {
                activeLights++;
            }
        }
    }

    private void Update()
    {
        if(activeLights == 6)
        {
            GetComponent<Animator>().SetTrigger("FlyAway");
        }
    }

    public void ToggleLight(int[] lightsToToggle)
    {
        foreach (int i in lightsToToggle)
        {


            if (AllLights[i].activeSelf)
            {
                AllLights[i].SetActive(false);
                activeLights--;
            }
            else
            {
                AllLights[i].SetActive(true);
                activeLights++;
            }
        }
    }
}
