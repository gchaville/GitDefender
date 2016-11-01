using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Repository : MonoBehaviour {

	private int depotHp;
	public int maxHp;
	private CameraManager cameraManager;
	public Slider sliderHp;

	public Sprite[] otherSprites;

	private bool alertIsLaunch;//pour changer la musique et les anims des "grounds" qu'une fois

	public GameObject fonduGameOver;
	public GameObject UIGameOver;
	private bool launchFonduGameOver = false;

	void Start () {
		cameraManager = GameManager.instance.getCamera ();
		depotHp = maxHp;
		sliderHp.value = depotHp;
		sliderHp.fillRect.GetComponent<Image> ().color = Color.green;
	}

	void Update () {
		if (depotHp <= maxHp / 2) {
			sliderHp.fillRect.GetComponent<Image> ().color = Color.yellow;
		}
		if (depotHp <= maxHp / 4) {
			sliderHp.fillRect.GetComponent<Image> ().color = Color.red;
		}
		sliderHp.value = depotHp;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Ennemy") {
			depotHp -= 10;
			cameraManager.setShake (0.5f);
			switchSprite ();
			StartCoroutine (slowMoEffect ());
			GameManager.instance.checkIfGameOver (this);
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

	public int getCurHp(){
		return depotHp;
	}

	IEnumerator GameOverEffect(){
		GameObject.Find ("Background").GetComponent<MusicManager> ().launchGameOverMusicEffect ();
		this.GetComponent<BoxCollider2D> ().enabled = false;
		Destroy (GetComponent<Rigidbody2D> ());
		cameraManager.setShake (8f);

		while (Time.timeScale > 0) {
			GameManager.instance.GetComponent<GlitchEffect> ().launchGlitchGameOver ();
			if (Time.timeScale - 0.1f < 0) {
				break;
			}
			else 
				Time.timeScale -= 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
		GameObject toInstantiate = Instantiate(fonduGameOver, transform) as GameObject;
		toInstantiate.transform.SetParent (this.transform.parent);
		yield return new WaitForSeconds(0.4f);
		toInstantiate = Instantiate(UIGameOver, transform) as GameObject;
		toInstantiate.GetComponent<GameOverUI> ().setGameOverPanel (GameManager.instance.getWave(), PlayerPrefs.GetInt("HighScore", 0));
		toInstantiate.transform.SetParent (this.transform.parent);
	}

	public void launchGameOverEffect(){
		StartCoroutine (GameOverEffect ());
	}
}
