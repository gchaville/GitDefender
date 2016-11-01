using UnityEngine;
using System.Collections;

public class BranchModule : MonoBehaviour {

    
	public Sprite damagedSprite;

    void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ennemy") {
            GetComponent<ModuleController>().life--;
			if (GetComponent<ModuleController>().life < 5) {
				GetComponent<SpriteRenderer> ().sprite = damagedSprite;
			}

			if (GetComponent<ModuleController>().life <= 0)
				Destroy (this.gameObject);
		}
    }
}
