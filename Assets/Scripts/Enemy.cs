using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private float moveSpeed;
    Vector3 direction;

	void Start () {
        moveSpeed = 5f;
        direction = Vector3.right;
	}

	void Update () {
        if (transform.position.x > 8)
            direction = -Vector3.right;
        else if (transform.position.x < -8)
            direction = Vector3.right;

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public void SetSpeed(float s) {
        moveSpeed = s;
    }

    void OnCollisionEnter2D(Collision2D other) {
        direction *= -1;
    }
}
