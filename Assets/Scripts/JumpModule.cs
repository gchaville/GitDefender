﻿using UnityEngine;
using System.Collections;

public class JumpModule : MonoBehaviour {

    private bool canJump;
    public int life;
    public float delay;
    public float pushForce;

	private Animator anim;

    void Start() {
		anim = GetComponent<Animator> ();
        canJump = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (canJump) {
            canJump = false;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
			anim.SetTrigger ("Action");
            rb.velocity = new Vector2(rb.velocity.x, pushForce);
            StartCoroutine(Delay());
            life--;
        }
        if (life <= 0)
            Destroy(gameObject);

    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(delay);
        canJump = true;
    }
}
