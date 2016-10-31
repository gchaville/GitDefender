using UnityEngine;
using System.Collections;

public class TeleportModule : MonoBehaviour {

    private bool canTeleport;
    public int life;
    public float delay;

    void Start() {
        canTeleport = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (canTeleport) {
            canTeleport = false;
            other.gameObject.GetComponent<Enemy>().TeleportToSpawnPos();
            StartCoroutine(Delay());
            life--;
        }
        if (life <= 0)
            Destroy(gameObject);

    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(delay);
        canTeleport = true;
    }
}
