using UnityEngine;
using System.Collections;

public class GroundEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void launchAlert(){
		GetComponent<Animator> ().SetBool ("isAlert", true);
	}
}
