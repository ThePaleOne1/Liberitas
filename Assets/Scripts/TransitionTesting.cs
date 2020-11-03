using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTesting : MonoBehaviour
{
    public Camera camera;
    MeshRenderer renderer;
    //private Material material;
    private Texture2D screenshot;

    public int resHeight;
    public int resWidth;

    
    // Start is called before the first frame update
    void Start()
    {
        resWidth = camera.pixelWidth;
        resHeight = camera.pixelHeight;

        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("pressed space to take a screenshot");
            TakeScreenshot();
        }

        
    }


    public void TakeScreenshot()
    {
        print("attempting to take screenshot");
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 100);
        camera.targetTexture = rt;

        screenshot = new Texture2D(resWidth, resHeight, TextureFormat.RGBA32, false);

        camera.Render();
        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenshot.Apply();
        camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        print("attempting to put screenshot into material");
        
        renderer.material.SetTexture("_MainTex", screenshot);
    }
}
