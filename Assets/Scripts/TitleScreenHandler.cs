using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenHandler : MonoBehaviour
{
	[SerializeField] GameObject titleScreen;
	[SerializeField] GameObject settingsScreen;
	[SerializeField] Slider masterVolumeSlider;
	[SerializeField] Slider sfxVolumeSlider;
	[SerializeField] Slider musicVolumeSlider;
	private AudioPlayer audioPlayer;

	private void Start()
	{
		SetGameData();
		AssignVolume();
		OpenTitleScreen();
	}

	private void SetGameData()
	{
		if (!PlayerPrefs.HasKey("level"))
		{
			PlayerPrefs.SetInt("level", 0);
		}
		
	}

	public void OpenTitleScreen()
	{
		Debug.Log("Open Title Screen");
		Debug.Log("Master: " + PlayerPrefs.GetFloat("MasterVolume"));
		Debug.Log("SFX: " + PlayerPrefs.GetFloat("SFXVolume"));
		Debug.Log("Music: " + PlayerPrefs.GetFloat("MusicVolume"));
		Debug.Log("Level: " + PlayerPrefs.GetInt("level"));

		settingsScreen.SetActive(false);
		titleScreen.SetActive(true);
	}

	private void AssignVolume()
	{
		audioPlayer = FindObjectOfType<AudioPlayer>();
		settingsScreen.SetActive(true);
		
		//GameObject[] temp = GameObject.FindGameObjectsWithTag("MasterVolumeSlider");
		//Debug.Log(temp[0].name);

		masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
		sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
		musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
	}

	public void PlayLevel()
	{
		int curLevel = PlayerPrefs.GetInt("level");
		if (curLevel == 0)
		{
			Debug.Log("Loading: Level_Lab-1");
			SceneManager.LoadScene("Level_Lab-1");
		}
		else if (curLevel == 1)
		{
			Debug.Log("Loading: Level_Lab-2");
			SceneManager.LoadScene("Level_Lab-2");
		}
		else if (curLevel == 2)
		{
			Debug.Log("Loading: Level_Lab-3");
			SceneManager.LoadScene("Level_Lab-3");
		}
	}

	public void OpenSettings()
	{
		Debug.Log("Open Settings");
		titleScreen.SetActive(false);
		settingsScreen.SetActive(true);
	}

	public void ExitGame()
	{
		// Close Game
		Debug.Log("Quit Game");
		PlayerPrefs.Save();
		Application.Quit();
	}

	public void ResetData()
	{
		Debug.Log("Resetting Level (" + PlayerPrefs.GetInt("level") + ") -> 0");
		PlayerPrefs.SetInt("level", 0);
		PlayerPrefs.Save();
	}
}
