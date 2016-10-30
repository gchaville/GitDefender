using UnityEngine;
using System.Collections;

public class Repository : MonoBehaviour {

	private int depotHp;
	public int maxHp;

	public Sprite[] otherSprites;

	void Start () {
		depotHp = maxHp;
	}

	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ennemy") {
			depotHp -= 10;
			print (depotHp.ToString ());
			switchSprite ();
			GameManager.instance.checkIfGameOver (depotHp);
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
}
