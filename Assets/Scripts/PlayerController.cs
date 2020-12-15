using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LevelChange lvlChange;
    
    public float Size = 1;
    public float sizeScale = 0.5f;

    SpriteRenderer sp;
    Animator anim;
    
    Pathfinding.AIPath AI;

    public GameObject targetObject;
    Vector3 target;

    RaycastHit2D hit;

    public GameObject fire;
    public GameObject RealFire;

    public AudioClip[] WoodFootSteps;
    public AudioClip[] RugFootSteps;
    public AudioClip[] StreetPavementFootSteps;
    public AudioClip[] StoneFloorFootSteps;
    public AudioClip[] ObservatoryRoofFootSteps;
    AudioSource aSource;

    public float timer = 1;
    public float FootstepDelay = 1;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        AI = transform.parent.GetComponent<Pathfinding.AIPath>();
        aSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        

        if (MyGameManager.GM.IsHoldingFlame)
        {
            fire.SetActive(true);
            RealFire.SetActive(true);
        }
        else
        {
            fire.SetActive(false);
            RealFire.SetActive(false);
        }

        if (timer < 0)
        {
            timer = FootstepDelay;
           

            switch (lvlChange.CurrentLevel - 1)
            {
                case 1:
                    aSource.PlayOneShot(WoodFootSteps[Random.Range(0, WoodFootSteps.Length - 1)]);
                    break;
                case 2:
                    aSource.PlayOneShot(StreetPavementFootSteps[Random.Range(0, WoodFootSteps.Length - 1)]);
                    break;
                case 3:
                    aSource.PlayOneShot(RugFootSteps[Random.Range(0, WoodFootSteps.Length - 1)]);
                    break;
                case 4:
                    aSource.PlayOneShot(StoneFloorFootSteps[Random.Range(0, WoodFootSteps.Length - 1)]);
                    break;
            }
        }

        if (AI.velocity.magnitude > 0.1f)
        {
            anim.SetBool("IsWalking", true);

            timer -= Time.deltaTime;

        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if(AI.velocity.x >= 0.1)
        {
            sp.flipX = true;
        }
        else if(AI.velocity.x < -0.1)
        {
            sp.flipX = false;
        }


    }
}
