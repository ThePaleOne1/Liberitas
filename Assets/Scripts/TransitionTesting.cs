using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTesting : MonoBehaviour
{
    public Camera camera;
    public Material material;
    public RenderTexture rendTex;

    public int resHeight;
    public int resWidth;
    // Start is called before the first frame update
    void Start()
    {
        

        rendTex.width = camera.pixelWidth;
        rendTex.height = camera.pixelHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            material.mainTexture = rendTex;
        }
    }
}
