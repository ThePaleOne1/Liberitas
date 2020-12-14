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

	public AudioSource aSource;
	public AudioClip tabAudio;

	[SerializeField] float InteractDistance = 1;

    Coroutine lastCoroutine;

    bool VirtualClick = false;
        
    public enum ObjectTag
    {
        Untagged, 
        Walkable, 
        PullTab, 
        Exit, 
        Candle,
        Flame,
        Door,
        Tutorial
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
        if (Input.GetMouseButtonDown(0) || VirtualClick) //when you click
        {
            VirtualClick = false;

            HitObject = null;
            HitPosition = Vector2.zero;
            //hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero); //perform a raycast
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                //store some information about the raycast hit
                HitPosition = hit.point;
                HitObject = hit.transform.gameObject;
            }


            print(HitObject.tag + "\n" + HitObject.name);



            //check what the tag of the hit was so we know what to do
            //whenever we add something new to click, 
            //just make a new tag and add any functionality in this big "else if" statement
            //make sure to leave the very last "else" statement so that we can catch anything thats not in yet

            //if pull tab
            if (HitObject.tag == ObjectTag.PullTab.ToString()) 
            {
                Toggleable tog = HitObject.GetComponent<Toggleable>();
                if( tog != null)
                {
                    if (tog.IsActive)
                    {
                        Animator anim = HitObject.GetComponent<Animator>();
                        anim.SetBool("IsTriggered", !anim.GetBool("IsTriggered"));
						aSource.PlayOneShot(tabAudio);

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

                if (lastCoroutine != null) StopCoroutine(lastCoroutine);
                lastCoroutine = StartCoroutine(WalkToInteract(HitObject));
            }
            //if door
            else if(HitObject.tag == ObjectTag.Door.ToString())
            {
                
				WalkToCursor(HitObject.transform.position);

                if(lastCoroutine != null) StopCoroutine(lastCoroutine);
				lastCoroutine = StartCoroutine(WalkToInteract(HitObject));
                
			}
            //if tutorial piece
            else if (HitObject.tag == ObjectTag.Tutorial.ToString())
            {
                HitObject.GetComponent<Interactable>().Interact();
                VirtualClick = true;
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
            //print("waiting until player has walked towards object");
            yield return new WaitUntil(() => CheckDistanceForInteract(obj));
            //print("is close enough to object");
            if (HitObject != obj) yield break;
            //print("near object, triggering interact");
            obj.GetComponent<Interactable>().Interact();
        }
    }
    public bool CheckDistanceForInteract(GameObject obj)
    {
        if(Vector2.Distance(MyGameManager.GM.InteractCenter.transform.position, obj.transform.position) < InteractDistance)
        {
            //print($"disctance check: {Vector2.Distance(MyGameManager.GM.InteractCenter.transform.position, obj.transform.position)} Close enough" );
            return true;
        }
        else
        {
            //print($"disctance check: {Vector2.Distance(MyGameManager.GM.InteractCenter.transform.position, obj.transform.position)} not close enough");
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
