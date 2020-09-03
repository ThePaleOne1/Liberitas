using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    public float Size = 1;
    public float sizeScale = 0.5f;

    SpriteRenderer sp;
    Animator anim;
    
    Pathfinding.AIPath AI;

    public GameObject targetObject;
    Vector3 target;

    RaycastHit2D hit;

    public GameObject fire;

    public AudioClip[] WoodFootSteps;
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
        }
        else
        {
            fire.SetActive(false);
        }

        if (timer < 0)
        {
            timer = FootstepDelay;
            aSource.PlayOneShot(WoodFootSteps[Random.Range(0, WoodFootSteps.Length - 1)]);
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

        if(AI.velocity.x > 0)
        {
            sp.flipX = true;
        }
        else if(AI.velocity.x < 0)
        {
            sp.flipX = false;
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
        //    target = hit.point;
        //}

    }
}
