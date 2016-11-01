using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BashWindows : MonoBehaviour {

	private Animator anim;
	public Text textClone;
	public Text textLog;
	public Animator glitch;
	public GameObject uiConflict;

	public float letterPause = 0.2f;
	string messageClone, messageLog;

	int state = 0;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		textClone = textClone.GetComponent<Text> ();
		textLog = textLog.GetComponent<Text> ();
		glitch = glitch.GetComponent<Animator> ();
		glitch.gameObject.SetActive (false);

		messageClone = textClone.text;
		textClone.text = "";
		messageLog = textLog.text;
		textLog.text = "";
		StartCoroutine(TypeText (messageClone, textClone));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator TypeText (string m, Text t) {
		foreach (char letter in m.ToCharArray()) {
			t.text += letter;
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}
		state++;
		checkState ();
	}

	IEnumerator Wait (float t) {
		yield return new WaitForSeconds (t); 
		state++;
		checkState ();
	}

	void checkState() {
		switch (state) {
		case 1:
			anim.SetBool ("Clonning", true);
			textClone.text = "";
			StartCoroutine(Wait(0.3F));
			break;
		case 2:
			StartCoroutine(TypeText (messageLog, textLog));
			break;
		case 3:
			anim.SetBool ("Logging", true);
			anim.SetBool ("Clonning", false);
			textLog.text = "";
			StartCoroutine(Wait(1.0F));
			break;
		case 4:
			glitch.gameObject.SetActive (true);
			//Camera main = Camera.main;
			//Vector3 v = main.ViewportToWorldPoint (new Vector3 (1f, 1f, 1f));
			GameObject toInstantiate = Instantiate (uiConflict, this.transform) as GameObject;
			//toInstantiate.transform.position = new Vector2 (0f, 0f);
			//toInstantiate.transform.position = v;
			break;
		}
	}
}
