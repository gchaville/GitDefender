using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private float moveSpeed;
    Vector3 direction;

	private Animator anim;

	private float glitchTimer;
	private float maxTimerGlitch = 1f;

	public string enemyName;

	void Start () {
		anim = GetComponent<Animator> ();
        moveSpeed = 2.5f;
        direction = Vector3.right;
		glitchTimer = maxTimerGlitch;
	}

	void Update () {
        transform.Translate(direction * moveSpeed * Time.deltaTime);

		if (glitchTimer > 0) {
			glitchTimer -= Time.deltaTime;
		} else {
			glitchAnimation ();
			glitchTimer = maxTimerGlitch;
		}
    }

    public void SetSpeed(float s) {
        moveSpeed = s;
    }

    void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Wall") {
			direction *= -1;
		}
    }

	void glitchAnimation(){
		int random = (int)Random.Range (0f, 2f);
		if (random == 0) {
			anim.SetTrigger ("isGlitch");
		}
	}
}
