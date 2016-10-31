using UnityEngine;
using System.Collections;

public class BranchModule : MonoBehaviour {

    public int life;

    void OnCollisionEnter2D(Collision2D other) {
        life--;

        if (life <= 0)
            Destroy(this.gameObject);
    }
}
