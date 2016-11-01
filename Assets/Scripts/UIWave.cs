using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIWave : MonoBehaviour {

	public GameObject textWaveNb;

	void Start () {
		Destroy (this.gameObject, 5f);
	}

	public void setNumberWave(string waveNumber){
		textWaveNb.GetComponent<Text>().text = waveNumber;
	}
}
