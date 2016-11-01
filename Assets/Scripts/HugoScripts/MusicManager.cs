using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
// script pour faire un effet de pitch sur la musique quand le dépot git prend un dommage

	private AudioSource mainMusic;
	private int pitchRepere = 0;//permet de repasser la musique au pitch de 1 près un damage sur le repository
	public AudioClip damagedMusic;

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

	public void launchDamagedMusic(){
		mainMusic.clip = damagedMusic;
		mainMusic.pitch = 1;
		mainMusic.Play ();
	}

	IEnumerator GameOverEffect(){
		launchDamagedMusic ();
		while (mainMusic.pitch>0) {
			mainMusic.pitch -= 0.1f;
			if (mainMusic.pitch - 0.1f > 0)
				mainMusic.pitch -= 0.05f;
			else
				mainMusic.pitch = 0;
			yield return new WaitForSeconds(0.1f);
		}
	}

	public void launchGameOverMusicEffect(){
		pitchRepere = 0;
		StartCoroutine (GameOverEffect ());
	}
}
