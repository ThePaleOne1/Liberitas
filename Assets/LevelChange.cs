using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public GameObject[] Levels;
    [Range(1,4)]
    public int CurrentLevel = 1;
    int LevelCheck = 1;


    void Start()
    {
        //making sure that the game starts at level 1
        foreach(GameObject level in Levels)
        {
            level.SetActive(false);
        }
        Levels[0].SetActive(true);
    }

    void Update()
    {
        //check if the level number has changed
        //if so, physically change the level and do anything else that might need to be done.
        if( CurrentLevel != LevelCheck)
        {
            print($"CurrentLevel was changed from {LevelCheck} to {CurrentLevel}");
            foreach (GameObject level in Levels)
            {
                level.SetActive(false);
            }
            Levels[CurrentLevel-1].SetActive(true);


            //keep this at the very bottom of the If(){}
            LevelCheck = CurrentLevel;
        }



        //temporary level changing by pressing the number buttons. this will be deleted in the end product
        //TODO: delete this before the final build!!!
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentLevel = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentLevel = 2;
        }
    }
}
