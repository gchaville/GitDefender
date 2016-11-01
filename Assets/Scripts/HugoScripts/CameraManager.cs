﻿using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	private float decreaseFactor = 1.0f;
	private float shake = 0f;
	private float shakeAmount = 0.1f;

	private Camera camera;

	void Start(){
		camera = this.GetComponent<Camera> ();
	}

	void Update() {
		if (shake > 0) {
			transform.localPosition = Random.insideUnitSphere * shakeAmount + new Vector3 (0f, 0f, -10f);
			shake -= Time.deltaTime * decreaseFactor;

		} else {
			shake = 0.0f;
            //
            transform.localPosition = new Vector3 (0f, 0f, -10f);
		}
	}

	public void setShake(float value){
		shake = value;
	}
}
