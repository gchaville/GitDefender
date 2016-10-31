﻿using UnityEngine;
using System.Collections;

public class SlowModule : MonoBehaviour {

    private bool canFreeze;
    public int life;
    public float delay;

    void Start() {
        canFreeze = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(canFreeze) {
            canFreeze = false;
            StartCoroutine(other.gameObject.GetComponent<Enemy>().Frozen());
            StartCoroutine(Delay());
            life--;
        }
        if (life <= 0)
            Destroy(gameObject);
        
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(delay);
        canFreeze = true;
    }
}
