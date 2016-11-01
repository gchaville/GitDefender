using UnityEngine;
using System.Collections;

public class EnnemyMovement : MonoBehaviour {

	Transform repository; // Prend la position du Repository
	public float Maxspeed = 1f;
	public float acceleration ;

	private Rigidbody2D rbody;

	private Transform init;

	private bool firstMovement = false;
	private bool firstHit = false;



	void Awake()
	{
		repository = GameObject.FindGameObjectWithTag ("Player").transform;
		rbody = gameObject.GetComponent<Rigidbody2D> ();

	}

	void CheckDirection(){
		var init = this.GetComponent<Transform> ();
		var XAxis = init.position.x;
		//        -     Vector(0,0,0)    +
		//		  -->  					<--
		// Si XAxix est Positif on déplace vers la Gauche
		// Si XAxix est Négatif on va vers la droite
		if (XAxis > 0)
			rbody.velocity = new Vector2 (acceleration * Maxspeed, rbody.velocity.y);
		else
			rbody.velocity = new Vector2 (-(acceleration * Maxspeed), rbody.velocity.y);
	}

	// Update is called once per frame
	void Update () {

		if (!firstMovement) {
			CheckDirection ();
			firstMovement = true;
		}

		if (rbody.velocity.magnitude > Maxspeed) {

			rbody.velocity = rbody.velocity.normalized * Maxspeed;
		}

		rbody.velocity = new Vector2 (rbody.velocity.x, rbody.velocity.y);
	}

	void OnCollisionEnter2D(Collision2D coll) {


		if (coll.gameObject.CompareTag ("Wall")) {
			Debug.Log ("Collision");
			var opposite = -(rbody.velocity);
			rbody.velocity = new Vector2(opposite.x*2,opposite.y*2);
			Debug.Log (rbody.velocity);
		} 
	}
}
