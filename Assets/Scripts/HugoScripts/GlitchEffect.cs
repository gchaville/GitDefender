﻿using UnityEngine;
using System.Collections;

public class GlitchEffect : MonoBehaviour {

	public GameObject glitchObject;
	public Sprite[] glitchSprites;
	private Vector3 screenPosition;

	void Update(){
		screenPosition = GameObject.Find ("FollowCamera").transform.position;
	}

	public void launchGlitch(){
		print (screenPosition);
		int nbGlitch = (int)Random.Range (20f, 50f);
		for (int i = 0; i < nbGlitch; i++) {
			GameObject toInstantiate = Instantiate (glitchObject, this.transform.position, Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<SpriteRenderer> ().color = new Color(Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			toInstantiate.GetComponent<SpriteRenderer>().sprite = glitchSprites[(int)Random.Range(0f, glitchSprites.Length)];
			toInstantiate.transform.position = new Vector3 (Random.Range (-9f+screenPosition.x, 9f+screenPosition.x), Random.Range (-5f, 5f), 0f);
			toInstantiate.transform.localScale = new Vector3 (Random.Range (0f, 2f), Random.Range (0f, 2f), 0f);
			Destroy(toInstantiate, Random.Range(0.1f, 0.5f));
		}
	}

	public void launchGlitchGameOver(){
		int nbGlitch = (int)Random.Range (20f, 50f);
		for (int i = 0; i < nbGlitch; i++) {
			GameObject toInstantiate = Instantiate (glitchObject, this.transform.position, Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<SpriteRenderer> ().color = new Color(Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			toInstantiate.GetComponent<SpriteRenderer>().sprite = glitchSprites[(int)Random.Range(0f, glitchSprites.Length)];
			toInstantiate.transform.position = new Vector3 (Random.Range (-9f+screenPosition.x, 9f+screenPosition.x), Random.Range (-5f, 5f), 0f);
			toInstantiate.transform.localScale = new Vector3 (Random.Range (0f, 2f), Random.Range (0f, 2f), 0f);
			Destroy(toInstantiate, Random.Range(5f, 10f));
		}
	}
}
