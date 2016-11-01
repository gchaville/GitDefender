using UnityEngine;
using System.Collections;

public class JumpModule : MonoBehaviour {

    private bool canJump;
    public float delay;
    public float pushForce;

	private Animator anim;

    void Start() {
		anim = GetComponent<Animator> ();
        canJump = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (canJump && other.tag == "Ennemy" && other.gameObject.GetComponent<Enemy>().IsFlying == false) {
            canJump = false;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
			anim.SetTrigger ("Action");
            rb.velocity = new Vector2(rb.velocity.x, pushForce);
            StartCoroutine(Delay());
            GetComponent<ModuleController>().life--;
        }
        if (GetComponent<ModuleController>().life <= 0)
            Destroy(gameObject);

    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(delay);
        canJump = true;
    }
}
