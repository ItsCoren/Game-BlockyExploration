using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
	[SerializeField] AudioSource jumpSound;
	[SerializeField] AudioSource deathSound;
	[SerializeField] AudioSource winSound;
	[SerializeField] AudioSource music;
	[SerializeField] AudioMixer mixer;
	static GameObject instance;
	private float masterVolume;
	private float sfxVolume;
	private float musicVolume;

	private void Start()
	{
		if (instance == null)
		{
			instance = gameObject;
			DontDestroyOnLoad(instance);
		}
		else
		{
			Destroy(gameObject);
			return;
		}
		

		if (!music.isPlaying)
		{
			music.Play();
		}
	}

	#region Play Sounds
	public void playJumpSound()
	{
		jumpSound.Play();
	}
	public void playDeathSound()
	{
		deathSound.Play();
	}
	public void playWinSound()
	{
		deathSound.Play();
	}
	#endregion
}
