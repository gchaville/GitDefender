using UnityEngine;
using System.Collections;

public class SlowModule : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<Enemy>().SetSpeed(2f);
    }

    void OnTriggerExit2D(Collider2D other) {
        other.gameObject.GetComponent<Enemy>().SetSpeed(5f);
    }
}
