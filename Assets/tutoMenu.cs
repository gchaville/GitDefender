using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class tutoMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			Application.LoadLevel ("BigSceneHugo");
		}
	
	}
}
