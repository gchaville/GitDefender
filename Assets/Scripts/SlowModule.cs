using UnityEngine;
using System.Collections;

public class SlowModule : MonoBehaviour {

    private bool canFreeze;
    public int life;
    public float delay;
	private Animator anim;

    void Start() {
		anim = GetComponent<Animator> ();
        canFreeze = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ennemy") {
			if (canFreeze) {
				canFreeze = false;
				anim.SetTrigger ("Action");
				StartCoroutine (other.gameObject.GetComponent<Enemy> ().Frozen ());
				StartCoroutine (Delay ());
				life--;
			}
			if (life <= 0)
				Destroy (gameObject);
		}
        
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(delay);
        canFreeze = true;
    }
}
