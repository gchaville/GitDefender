using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
    public float moveSpeed;
    Vector3 direction;
    public Vector3 spawnPos;
    public bool IsFlying;

	private Animator anim;

	private float glitchTimer;
	private float maxTimerGlitch = 1f;

	public string enemyName;

    public int freezeTime;

	void Start () {
		anim = GetComponent<Animator> ();

        spawnPos = transform.position;
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

	public void setdirection(Vector3 dir){
		direction = dir;
	}

	public void launchDeath(){
		StartCoroutine (Die ());
	}

    public void TeleportToSpawnPos() {
        transform.position = spawnPos;
    }

	public IEnumerator Die(){
		enabled = false;
		this.GetComponent<BoxCollider2D> ().enabled = false;
		Destroy(this.GetComponent<Rigidbody2D>());
		anim.SetTrigger ("isDead");
		yield return new WaitForSeconds (0.4f);
		Destroy (this.gameObject);
        GameManager.instance.monstersLeft--;
	}

    public IEnumerator Frozen() {
        moveSpeed = 1;
		GetComponent<SpriteRenderer> ().color = Color.blue;
        yield return new WaitForSeconds(freezeTime);
		GetComponent<SpriteRenderer> ().color = Color.white;
        moveSpeed = 2.5f;
    }
}
