using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {

	public GameObject waveText;
	public GameObject highScore;

	public void setGameOverPanel(int wave, int high){
		waveText.GetComponent<Text> ().text = "wave : " + wave.ToString ();
		highScore.GetComponent<Text> ().text = "high score : " + high.ToString ();
	}
}
