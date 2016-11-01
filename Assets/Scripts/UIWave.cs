using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIWave : MonoBehaviour {

	public GameObject textReceiver;
	private Text textWaveNb;

	void Start () {
		Destroy (this.gameObject, 5f);
	}

	public void setText(string text, int number){
		if (number == -1) {
			// est une vague
			textReceiver.GetComponent<Text>().text= "wave " + text;
		} else {
			textReceiver.GetComponent<Text>().text=text;
		}
	}
}
