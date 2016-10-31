using UnityEngine;
using System.Collections;

public class Repository : MonoBehaviour {

	private int depotHp;
	public int maxHp;
	private CameraManager cameraManager;

	public Sprite[] otherSprites;

	private bool alertIsLaunch;//pour changer la musique et les anims des "grounds" qu'une fois

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
			if (alertIsLaunch)
				return;
			alertIsLaunch = true;
			GetComponent<SpriteRenderer> ().sprite = otherSprites [1];
			launchGroundAlert ();
			GameObject.Find ("Background").GetComponent<MusicManager> ().launchDamagedMusic ();
		}else if (depotHp <= maxHp / 2) {
			GetComponent<SpriteRenderer> ().sprite = otherSprites [0];
		} 
	}

	IEnumerator slowMoEffect(){
		Time.timeScale = Random.Range (0.4f, 0.7f);
		yield return new WaitForSeconds (0.3f);
		Time.timeScale = 1f;
	}

	public void launchGroundAlert(){
	//lance les animations des walls et des grounds
		GameObject[] ground = GameObject.FindGameObjectsWithTag("ground");
		GameObject[] wall = GameObject.FindGameObjectsWithTag("Wall");
		foreach (GameObject effectAlert in ground) {
			effectAlert.GetComponent<GroundEffect> ().launchAlert ();
		}
		foreach (GameObject effectAlert in wall) {
			effectAlert.GetComponent<GroundEffect> ().launchAlert ();
		}
	}
}
