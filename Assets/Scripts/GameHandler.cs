using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

	[SerializeField] GameObject pauseScreen;
	[SerializeField] Slider masterVolumeSlider;
	[SerializeField] Slider sfxVolumeSlider;
	[SerializeField] Slider musicVolumeSlider;
	private AudioPlayer audioPlayer;
	// Start is called before the first frame update
	void Start()
	{
		AssignVolume();
		pauseScreen.SetActive(false);
	}

	private void AssignVolume()
	{
		audioPlayer = FindObjectOfType<AudioPlayer>();
		pauseScreen.SetActive(true);
		
		//GameObject[] temp = GameObject.FindGameObjectsWithTag("MasterVolumeSlider");
		//Debug.Log(temp[0].name);

		masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
		sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
		musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseGame();
		}
	}

	public void PauseGame()
	{
		if (pauseScreen.activeSelf)
		{
			Debug.Log("Close Settings");
			pauseScreen.SetActive(false);
			Time.timeScale = 1f;
		}
		else
		{
			Time.timeScale = 0f;
			Debug.Log("Open Settings");
			pauseScreen.SetActive(true);
		}
	}

	public void Home()
	{
		Time.timeScale = 1f;
		Debug.Log("Loading: TitleScreen");
		SceneManager.LoadScene("TitleScreen");
	}

	public void LevelComplete()
	{
		Debug.Log(SceneManager.GetActiveScene().name + " Complete");
		int curLevel = PlayerPrefs.GetInt("level") + 1;
		
		if (curLevel < 3)
		{
			PlayerPrefs.SetInt("level", curLevel);
			PlayerPrefs.Save();
			if (curLevel == 1)
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
		else
		{
			Debug.Log("Resetting Level (" + PlayerPrefs.GetInt("level") + ") -> 0");
			PlayerPrefs.SetInt("level", 0);
			PlayerPrefs.Save();
			SceneManager.LoadScene("TitleScreen");
		}
	}

	public void PlayLevel()
	{
		int curLevel = PlayerPrefs.GetInt("level");
		Debug.Log("PlayLevel(level=" + curLevel + ")");
		
	}

}
