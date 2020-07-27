using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontBackObject : MonoBehaviour
{
    public GameObject player;

    public int backLayer = 5;
    public int frontLayer = 15;

    SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= player.transform.position.y)
        {
            sp.sortingOrder = frontLayer;
        }
        else
        {
            sp.sortingOrder = backLayer;
        }
    }
}
