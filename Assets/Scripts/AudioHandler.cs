using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{

	[SerializeField] AudioMixer mixer;
	private float masterVolume;
	private float sfxVolume;
	private float musicVolume;

	// Start is called before the first frame update
	void Start()
	{
		if (!PlayerPrefs.HasKey("MasterVolume"))
		{
			Debug.Log("Creating <MasterVolume>");
			PlayerPrefs.SetFloat("MasterVolume", 0.5f);
		}
		if (!PlayerPrefs.HasKey("SFXVolume"))
		{
			Debug.Log("Creating <SFXVolume>");
			PlayerPrefs.SetFloat("SFXVolume", 0.5f);
		}
		if (!PlayerPrefs.HasKey("MusicVolume"))
		{
			Debug.Log("Creating <MusicVolume>");
			PlayerPrefs.SetFloat("MusicVolume", 0.5f);
		}
		masterVolume = PlayerPrefs.GetFloat("MasterVolume");
		sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
		musicVolume = PlayerPrefs.GetFloat("MusicVolume");
	}

	private float GetMasterVolume()
	{
		return masterVolume;
	}

	public void SetMasterVolume(float sliderValue)
	{
		if (sliderValue == 0.123456f) return;
		Debug.Log("Updated <MasterVolume> = " + sliderValue);
		masterVolume = sliderValue;
		PlayerPrefs.SetFloat("MasterVolume", masterVolume);
		mixer.SetFloat("Master",Mathf.Log10(masterVolume)*20);
		PlayerPrefs.Save();
	}

	private float GetSFXVolume()
	{
		return sfxVolume;
	}

	public void SetSFXVolume(float sliderValue)
	{
		if (sliderValue == 0.123456f) return;
		Debug.Log("Updated <SFXVolume> = " + sliderValue);
		sfxVolume = sliderValue;
		PlayerPrefs.SetFloat("SFXVolume", sliderValue);
		mixer.SetFloat("SFX", Mathf.Log10(sliderValue)*20);
		PlayerPrefs.Save();
	}

	private float GetMusicVolume()
	{
		return musicVolume;
	}

	public void SetMusicVolume(float sliderValue)
	{
		if (sliderValue == 0.123456f) return;
		Debug.Log("Updated <MusicVolume> = " + sliderValue);
		musicVolume = sliderValue;
		PlayerPrefs.SetFloat("MusicVolume", sliderValue);
		mixer.SetFloat("Music", Mathf.Log10(sliderValue)*20);
		PlayerPrefs.Save();
	}
}
