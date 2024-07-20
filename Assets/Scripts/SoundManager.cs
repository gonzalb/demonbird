using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip flySound;
	
	public static AudioClip gamestart00Sound;
	public static AudioClip gamestart01Sound;

	public static AudioClip gameover00Sound;
	public static AudioClip gameover01Sound;
	public static AudioClip gameover02Sound;

	public static bool musicON = true;

	static AudioSource AudioSource;
	// Use this for initialization
	void Start () {	

		flySound = Resources.Load<AudioClip>("fly");

		gamestart00Sound = Resources.Load<AudioClip>("gamestart00");
		gamestart01Sound = Resources.Load<AudioClip>("gamestart01");

		gameover00Sound = Resources.Load<AudioClip>("gameover00");
		gameover01Sound = Resources.Load<AudioClip>("gameover01");
		gameover02Sound = Resources.Load<AudioClip>("gameover02");

		AudioSource = GetComponent<AudioSource>();
	}
	
	public static void PlaySound (string clip)
	{
		if (musicON)
		{
			switch (clip)
			{			
				case "gamestart00":
					AudioSource.PlayOneShot(gamestart00Sound);
					break;	

				case "gamestart01":
					AudioSource.PlayOneShot(gamestart01Sound);
					break;	

				case "gameover00":
					AudioSource.PlayOneShot(gameover00Sound);
					break;
				
				case "gameover01":
					AudioSource.PlayOneShot(gameover01Sound);
					break;

				case "gameover02":
					AudioSource.PlayOneShot(gameover02Sound);
					break;

				case "fly":
					AudioSource.PlayOneShot(flySound);
					break;				
			}
		}			
	}	
	
	public static void PlayMusic()
	{
		AudioSource.Play();
	}

	public static void PauseMusic()
	{
		AudioSource.Pause();
	}
}
