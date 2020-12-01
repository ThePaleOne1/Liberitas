/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{

	public AudioMixer audioMixer;
	public Dropdown resolutionDropdown;
	public Slider volumeSlider;
	float currentVolume;
	Resolution[] resolutions;

	// Start is called before the first frame update
	void Start()
	{
		resolutionDropdown.ClearOptions();
		List<string> options = new List<string>();
		resolutions = Screen.resolutions;
		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " +
					 resolutions[i].height;
			options.Add(option);
			if (resolutions[i].width == Screen.currentResolution.width
				  && resolutions[i].height == Screen.currentResolution.height)
				currentResolutionIndex = i;
		}
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.RefreshShownValue();
		LoadSettings(currentResolutionIndex);
	}

	// Update is called once per frame
	void Update()
	{

	}


	//TODO: Set the AudioSource in each scene to have the audio mixer 'Audio Master' to be counted for by the settings script.
	public void SetMasterVolume(float volume)
	{
		audioMixer.SetFloat("masterVolume", volume);
		//currentVolume = volume;
	}


	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}


	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width,
				  resolution.height, Screen.fullScreen);
	}

	public void SaveSettings()
	{
		PlayerPrefs.SetInt("ResolutionPreference",
				   resolutionDropdown.value);
		PlayerPrefs.SetInt("FullscreenPreference",
				   Convert.ToInt32(Screen.fullScreen));
		PlayerPrefs.SetFloat("VolumePreference",
				   currentVolume);
	}

	public void LoadSettings(int currentResolutionIndex)
	{
		if (PlayerPrefs.HasKey("ResolutionPreference"))
			resolutionDropdown.value =
						 PlayerPrefs.GetInt("ResolutionPreference");
		else
			resolutionDropdown.value = currentResolutionIndex;
		if (PlayerPrefs.HasKey("FullscreenPreference"))
			Screen.fullScreen =
			Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
		else
			Screen.fullScreen = true;
		if (PlayerPrefs.HasKey("VolumePreference"))
			volumeSlider.value =
						PlayerPrefs.GetFloat("VolumePreference");
		else
			volumeSlider.value =
						PlayerPrefs.GetFloat("VolumePreference");
	}

}
