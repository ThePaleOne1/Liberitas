using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class LevelChange : MonoBehaviour
{
    public AstarPath astarPath;

    public AudioSource BackgroundAudioSource;
    public AudioClip[] BackgroundMusic;
    

    public GameObject player;
    public GameObject walkTarget;
    public GameObject[] Levels;
    public float[] PlayerScalePerLevel;
    public GameObject[] StartingPosPerLevel;

    public SpriteRenderer BackPageSpriteRenderer;
    public Sprite[] BackPages;

    public bool[] IsFlameLitOnStart;

    [Range(1,5)]
    public int CurrentLevel = 1;
    int LevelCheck = 1;

    public Animator PageAnim;
    public GameObject Pages;

    public Camera RenderCamera;
    public RenderTexture rt;
    public SkinnedMeshRenderer PageSkinnedMeshRenderer;
    private Texture2D screenshot;

    public int resHeight;
    public int resWidth;

    public bool saveScreenshots = false;
    public int i = 0;

    void Start()
    {
        Pages.SetActive(false);
        //resWidth = RenderCamera.pixelWidth;
        //resHeight = RenderCamera.pixelHeight;
        resWidth = 290;
        resHeight = 290;
        
        print($"ON START\nCamera resolution: {RenderCamera.pixelWidth} x {RenderCamera.pixelHeight}\nVariableResolution: {resWidth} x {resHeight}");

        //making sure that the game starts at the level set in inspector
        DisableAllLevels();
        EnableCurrentLevel();
        
    }

    void Update()
    {
        //check if the level number has changed
        //if so, physically change the level and do anything else that might need to be done.
        if( CurrentLevel != LevelCheck)
        {
            Pages.SetActive(true);
            PageAnim.SetTrigger("Flip");
            //keep this at the very bottom of the If(){}
            LevelCheck = CurrentLevel;
        }


        //temporary level changing by pressing the number buttons. this will be deleted in the end product
        //TODO: delete this before the final build!!!
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentLevel = 1;
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentLevel = 2;
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentLevel = 3;

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentLevel = 4;

        }
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			CurrentLevel = 5;

		}
	}

    
    public void DisableAllLevels()
    {
        
        player.SetActive(false);
        foreach (GameObject level in Levels)
        {
            level.SetActive(false);
        }
       
    }

    public void EnableCurrentLevel()
    {
        //BackgroundAudioSource.clip = (BackgroundMusic[CurrentLevel - 1]);

        Levels[CurrentLevel - 1].SetActive(true);
        Pages.SetActive(false);
        
            player.SetActive(true);
        
        
        Vector3 startPos = StartingPosPerLevel[CurrentLevel - 1].transform.position;
        float scale = PlayerScalePerLevel[CurrentLevel - 1];

        player.transform.localScale = new Vector3(scale, scale, 1);
        player.GetComponent<AIPath>().Teleport(startPos, true);
        walkTarget.transform.position = startPos;
        player.GetComponent<AIPath>().SetPath(null);

        MyGameManager.GM.IsHoldingFlame = IsFlameLitOnStart[CurrentLevel - 1];

        astarPath.Scan();
    }



    public void TakeScreenshot()
    {
        


        Pages.SetActive(false);

        BackPageSpriteRenderer.gameObject.SetActive(true);
        BackPageSpriteRenderer.sprite = BackPages[CurrentLevel-1];
        

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 100);

        
        RenderCamera.targetTexture = rt;

        screenshot = new Texture2D(resWidth, resHeight, TextureFormat.RGBA32, false);

        RenderCamera.Render();
        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, 1280, 1280), 0, 0);
        screenshot.Apply();
        RenderCamera.targetTexture = null;
        RenderTexture.active = null;
        //Destroy(rt);

        // Encode texture into PNG
        byte[] bytes = screenshot.EncodeToPNG();


        // For testing purposes, also write to a file in the project folder
        if (saveScreenshots)
        {
            File.WriteAllBytes(Application.dataPath + $"/screenshots/Screenshot{i}.png", bytes);
            i++;
        }

        print("attempting to put screenshot into material");

        //PageMeshRenderer.material.SetTexture("_MainTex", screenshot);
        PageSkinnedMeshRenderer.material.SetTexture("_MainTex", screenshot);

        Pages.SetActive(true);
        BackPageSpriteRenderer.gameObject.SetActive(false);

    }

	public void StartGame()
	{
		CurrentLevel = 2;
        player.SetActive(true);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
