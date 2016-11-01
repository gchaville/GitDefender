using UnityEngine;
using System.Collections;

public class BranchModule : MonoBehaviour {

    public int life;
	public Sprite damagedSprite;

    void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ennemy") {
			life--;
			if (life < 5) {
				GetComponent<SpriteRenderer> ().sprite = damagedSprite;
			}

			if (life <= 0)
				Destroy (this.gameObject);
		}
    }
}
