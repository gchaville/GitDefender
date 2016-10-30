using UnityEngine;
using System.Collections;

public class EnnemyMovement : MonoBehaviour {

	Transform repository; // Prend la position du Repository
	public float Maxspeed = 1f;
	public float acceleration ;

	private Rigidbody2D rbody;

	private Transform init;



	void Awake()
	{
		repository = GameObject.FindGameObjectWithTag ("Player").transform;
		rbody = gameObject.GetComponent<Rigidbody2D> ();

	}

	void Start(){
		var init = this.GetComponent<Transform> ();
		var XAxis = init.position.x;
		//        -     Vector(0,0,0)    +
		//		  -->  					<--
		// Si XAxix est Positif on déplace vers la Gauche
		// Si XAxix est Négatif on va vers la droite
		if (XAxis > 0)
			rbody.AddForce(Vector2.left,ForceMode2D.Impulse);
		else
			rbody.AddForce (Vector2.right,ForceMode2D.Impulse);
	}

	// Update is called once per frame
	void Update () {

		if (rbody.velocity.magnitude > Maxspeed) {

			rbody.velocity = rbody.velocity.normalized * Maxspeed;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag ("Wall")) {
			var opposite = -(rbody.velocity);
			rbody.AddForce (opposite, ForceMode2D.Impulse);
		}

	}

}
