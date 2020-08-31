using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastOnClick : MonoBehaviour
{
    RaycastHit2D hit;
    Vector2 HitPosition = Vector2.zero;
    GameObject HitObject;

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
        Flame
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
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero); //perform a raycast
            
            //store some information about the raycast hit
            HitPosition = hit.point;
            HitObject = hit.transform.gameObject;



            //check what the tag of the hit was so we know what to do
            //whenever we add something new to click, 
            //just make a new tag and add any functionality in this big "else if" statement
            //make sure to leave the very last "else" statement so that we can catch anything thats not in yet
            print(HitObject.tag);
            if(HitObject.tag == ObjectTag.PullTab.ToString()) // pull tab
            {
                Toggleable tog = HitObject.GetComponent<Toggleable>();
                if( tog != null)
                {
                    if (tog.IsActive)
                    {
                        if (!tog.Inverted)
                        {
                            Animator anim = HitObject.GetComponent<Animator>();
                            anim.SetBool("IsTriggered", !anim.GetBool("IsTriggered"));
                        }
                    }
                    else
                    {
                        if (tog.Inverted)
                        {
                            Animator anim = HitObject.GetComponent<Animator>();
                            anim.SetBool("IsTriggered", !anim.GetBool("IsTriggered"));
                        }
                    }
                }
                else
                {
                    Animator anim = HitObject.GetComponent<Animator>();
                    anim.SetBool("IsTriggered", !anim.GetBool("IsTriggered"));
                }

                
            }
            else if (HitObject.tag == ObjectTag.Walkable.ToString() || HitObject.tag == ObjectTag.Untagged.ToString())
            {
                WalkToCursor(HitPosition);
            }
            else if(HitObject.tag == ObjectTag.Candle.ToString())
            {
                WalkToCursor(HitObject.transform.parent.position);
                StartCoroutine(WalkToInteract(HitObject));
            }
            else if(HitObject.tag == ObjectTag.Flame.ToString())
            {
                
            }
            else
            {
                //use this to catch anything that we forgot to put in
                Debug.Log($"Hit object with tag '{HitObject.tag}'... This tag was not found in the RayCastOnClick() script");
            }


        }
    }


    IEnumerator WalkToInteract(GameObject obj)
    {
        yield return new WaitUntil(() => CheckDistanceForInteract(obj));
        if (HitObject != obj) yield break;
        obj.GetComponent<Interactable>().Interact();

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
        PlayerWalkTarget.transform.position = position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (MyGameManager.GM.InteractCenter != null)
        {
            Gizmos.DrawWireSphere(MyGameManager.GM.InteractCenter.transform.position, InteractDistance);
        }
    }
}
