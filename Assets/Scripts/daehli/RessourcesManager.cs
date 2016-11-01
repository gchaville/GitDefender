using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RessourcesManager : MonoBehaviour {

	public static int ressources;

	Text text;

	// Use this for initialization
	void Awake () {
		ressources = 0;
		text = GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		text.text = "ressources " + ressources;
	
	}
}
