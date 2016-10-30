using UnityEngine;
using System.Collections;

public class Repository : MonoBehaviour {

	public int depotHp;
	private int maxHp;

	public Sprite[] otherSprites;

	void Start () {
		maxHp = depotHp;
	}

	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ennemy") {
			depotHp -= 10;
			switchSprite ();
			GameManager.instance.checkIfGameOver (depotHp);
			Destroy (other.gameObject);
		}
	}

	public void switchSprite(){
		if (depotHp < (maxHp / 2)) {
			GetComponent<SpriteRenderer> ().sprite = otherSprites [0];
		} else if (depotHp < (maxHp / 4)) {
			GetComponent<SpriteRenderer> ().sprite = otherSprites [1];
		}
	}
}
