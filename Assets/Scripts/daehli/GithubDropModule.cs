using UnityEngine;
using System.Collections;

public class GithubDropModule : MonoBehaviour {

	GameObject Github;
	Transform githubCurrentPosition;

	int [] list; // Pour l'instant liste de Int 
	// Liste de module 

	// Liste d'objet recent

	// Use this for initialization
	void Awake () {

		Github = GameObject.FindGameObjectWithTag("Github");

		githubCurrentPosition = Github.transform;
	
	}
	
	// Update is called once per frame	
	void Update () {

		if (true) {// MouseEvent
			DropModule ();
		}
	
	}


	void DropModule(){

		if (list.Length != 0) {
			// Faire Droper l'objet
		}
		
	}
}
