using UnityEngine;
using System.Collections;

public class KillModule : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
