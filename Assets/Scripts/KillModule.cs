using UnityEngine;
using System.Collections;

public class KillModule : MonoBehaviour {

    private bool canKill;
    public float delay;
	private Animator anim;

    void Start() {
		anim = GetComponent<Animator> ();
        canKill = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ennemy" && other.gameObject.GetComponent<Enemy>().IsFlying == false) {
			if (canKill) {
				canKill = false;
				anim.SetTrigger ("Action");
				other.GetComponent<Enemy> ().launchDeath ();
                GetComponent<ModuleController>().life--;
				StartCoroutine (Delay ());
			}
            if (GetComponent<ModuleController>().life <= 0)
            {
                GetComponent<ModuleController>().SetBusy();
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(delay);
        canKill = true;
    }
}
