using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontBackObject : MonoBehaviour
{
    

    public int backLayer = -10;
    public int frontLayer = 10;

    SpriteRenderer sp;

    public float offset = 0;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + offset <= MyGameManager.GM.Player.transform.position.y)
        {
            sp.sortingOrder = frontLayer;
        }
        else
        {
            sp.sortingOrder = backLayer;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawIcon(new Vector3( transform.position.x,transform.position.y + offset, transform.position.z), "F/B Offset",true);
    }
}
