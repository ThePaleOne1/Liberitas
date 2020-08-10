using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    public float Size = 1;
    public float sizeScale = 0.5f;

    SpriteRenderer sp;


    public GameObject targetObject;
    Vector3 target;

    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //sp.transform.localScale = Vector3.one * Size * (1 - (transform.position.y/sizeScale));



        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
            target = hit.point;
        }

        //if (hit.collider != null)
        //{
            //targetObject.transform.position = target;
        //}
    }
}
