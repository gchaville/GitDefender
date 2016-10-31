using UnityEngine;
using System.Collections;

public class KillModule : MonoBehaviour {

    private bool canKill;
    public int life;
    public float delay;

    void Start() {
        canKill = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(canKill) {
            canKill = false;
            Destroy(other.gameObject);
            life--;
            StartCoroutine(Delay());
        }
        if (life <= 0)
            Destroy(gameObject);
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(delay);
        canKill = true;
    }
}
