using UnityEngine;
using System.Collections;

public class KillModule : MonoBehaviour {

    private bool canKill;
    public int life;
    public float delay;
	private Animator anim;

    void Start() {
		anim = GetComponent<Animator> ();
        canKill = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ennemy") {
			if (canKill) {
				canKill = false;
				anim.SetTrigger ("Action");
				other.GetComponent<Enemy> ().launchDeath ();
				life--;
				StartCoroutine (Delay ());
			}
			if (life <= 0)
				Destroy (gameObject);
		}
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(delay);
        canKill = true;
    }
}
