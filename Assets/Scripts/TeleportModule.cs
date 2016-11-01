using UnityEngine;
using System.Collections;

public class TeleportModule : MonoBehaviour {

    private bool canTeleport;
    public float delay;
	private Animator anim;

    void Start() {
		anim = GetComponent<Animator> ();
        canTeleport = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ennemy") {
			if (canTeleport) {
				canTeleport = false;
				anim.SetTrigger ("Action");
				other.gameObject.GetComponent<Enemy> ().TeleportToSpawnPos ();
				StartCoroutine (Delay ());
                GetComponent<ModuleController>().life--;
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
        canTeleport = true;
    }
}
