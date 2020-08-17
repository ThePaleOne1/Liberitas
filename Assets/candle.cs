using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candle : MonoBehaviour
{
    public Toggleable pullTab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTabActive()
    {
        pullTab.GetComponent<Toggleable>().IsActive = true;

    }

    public void SetTabInactive()
    {
        pullTab.GetComponent<Toggleable>().IsActive = false;
    }
}
