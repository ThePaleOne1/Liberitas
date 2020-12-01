using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastOnClick : MonoBehaviour
{
    RaycastHit2D hit;
    Vector2 HitPosition = Vector2.zero;
    GameObject HitObject;

    public bool PlayerCanWalk = false;
    public GameObject PlayerWalkTarget;

    public bool HasFlame = false;
    GameObject heldFlame;
    public GameObject player;

    [SerializeField] float InteractDistance = 0.5f;
   

        
    public enum ObjectTag
    {
        Untagged, 
        Walkable, 
        PullTab, 
        Exit, 
        Candle,
        Flame,
        Door
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"Tag Testing: {ObjectTag.Walkable.ToString()}, {ObjectTag.PullTab.ToString()}");
        player = MyGameManager.GM.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //when you click
        {
            //hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero); //perform a raycast
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                //store some information about the raycast hit
                HitPosition = hit.point;
                HitObject = hit.transform.gameObject;
            }



            //check what the tag of the hit was so we know what to do
            //whenever we add something new to click, 
            //just make a new tag and add any functionality in this big "else if" statement
            //make sure to leave the very last "else" statement so that we can catch anything thats not in yet
            print(HitObject.tag + "\n" + HitObject.name);
            //if pull tab
            if(HitObject.tag == ObjectTag.PullTab.ToString()) 
            {
                Toggleable tog = HitObject.GetComponent<Toggleable>();
                if( tog != null)
                {
                    if (tog.IsActive)
                    {
                        Animator anim = HitObject.GetComponent<Animator>();
                        anim.SetBool("IsTriggered", !anim.GetBool("IsTriggered"));
                    }
                }                
            }
            //if walkable terrain
            else if (HitObject.tag == ObjectTag.Walkable.ToString() || HitObject.tag == ObjectTag.Untagged.ToString())
            {
                WalkToCursor(HitPosition);
            }
            //if candle
            else if(HitObject.tag == ObjectTag.Candle.ToString())
            {
                WalkToCursor(HitObject.transform.parent.position);
                StartCoroutine(WalkToInteract(HitObject));
            }
            //if door
            else if(HitObject.tag == ObjectTag.Door.ToString())
            {
                
            }
            else
            {
                //use this to catch anything that we forgot to put in
                Debug.LogWarning($"Hit object with tag '{HitObject.tag}'... This tag was not found in the RayCastOnClick() script");
            }


        }
    }


    IEnumerator WalkToInteract(GameObject obj)
    {
        if (PlayerCanWalk)
        {
            yield return new WaitUntil(() => CheckDistanceForInteract(obj));
            if (HitObject != obj) yield break;
            obj.GetComponent<Interactable>().Interact();
        }
    }
    public bool CheckDistanceForInteract(GameObject obj)
    {
        if(Vector2.Distance(MyGameManager.GM.InteractCenter.transform.position, obj.transform.position) < InteractDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void WalkToCursor(Vector3 position)
    {
        if (PlayerCanWalk)
        {
            PlayerWalkTarget.transform.position = position;
        }
    }

}
