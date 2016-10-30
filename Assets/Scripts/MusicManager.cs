using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
// script pour faire un effet de pitch sur la musique quand le dépot git prend un dommage

	private AudioSource mainMusic;
	private bool isGlitchingEffect = false;
	private int pitchRepere = 0;

	void Start () {
		mainMusic = GetComponent<AudioSource> ();
	}

	void Update () {
		if (pitchRepere == 0)
			return;
		if (pitchRepere == -1) {
			if (mainMusic.pitch < 1) {
				mainMusic.pitch += Time.deltaTime;
			} else {
				mainMusic.pitch = 1;
				pitchRepere = 0;
			}
		} else if (pitchRepere == 1) {
			if (mainMusic.pitch > 1) {
				mainMusic.pitch -= Time.deltaTime;
			} else {
				mainMusic.pitch = 1;
				pitchRepere = 0;
			}
		}
	}

	public void launchPitchEffect(){
		mainMusic.pitch = Random.Range (0f, 2f);
		if (mainMusic.pitch <= 1) {
			pitchRepere = -1;
		} else {
			pitchRepere = 1;
		}
	}
}
