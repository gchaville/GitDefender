using UnityEngine;
using System.Collections;

public class BranchModule : MonoBehaviour {

    private int life;

	void Start () {
        life = 3;
	}
    
    void OnCollisionEnter2D(Collision2D other) {
        life--;

        if (life <= 0)
            Destroy(this.gameObject);
    }
}
