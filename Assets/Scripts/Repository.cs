using UnityEngine;
using System.Collections;

public class Repository : MonoBehaviour {

	private int depotHp;
	public int maxHp;
	private CameraManager cameraManager;

	public Sprite[] otherSprites;

	void Start () {
		cameraManager = GameManager.instance.getCamera ();
		depotHp = maxHp;
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Ennemy") {
			depotHp -= 10;
			cameraManager.setShake (0.5f);
			switchSprite ();
			StartCoroutine (slowMoEffect ());
			GameManager.instance.checkIfGameOver (depotHp);
			GameObject.Find ("Background").GetComponent<MusicManager> ().launchPitchEffect ();
			GameManager.instance.GetComponent<GlitchEffect> ().launchGlitch ();
			other.gameObject.GetComponent<Enemy> ().launchDeath();
		}
	}

	public void switchSprite(){
		if (depotHp <= maxHp / 4) {
			GetComponent<SpriteRenderer> ().sprite = otherSprites [1];
		}else if (depotHp <= maxHp / 2) {
			GetComponent<SpriteRenderer> ().sprite = otherSprites [0];
		} 
	}

	IEnumerator slowMoEffect(){
		Time.timeScale = Random.Range (0.4f, 0.7f);
		yield return new WaitForSeconds (0.3f);
		Time.timeScale = 1f;
	}
}
