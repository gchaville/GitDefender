using UnityEngine;
using System.Collections;

public class GithubMovement : MonoBehaviour {

	GameObject ennemy;
	Transform ennemyTransform;
	NavMeshAgent nav;
	EnnemyHealth ennemyHealth;
	private Transform initPoint;

	// Use this for initialization
	void Awake () {
		initPoint = GetComponent<Transform> ();
		ennemy = GameObject.FindGameObjectWithTag ("Ennemy");
		ennemyTransform = ennemy.transform;
		ennemyHealth = ennemy.GetComponent<EnnemyHealth> ();
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ennemyHealth.currentHealth > 0) {
			Debug.Log (ennemyTransform.position);
			nav.SetDestination (ennemyTransform.position);
		} else {
			nav.SetDestination (initPoint.position);
		}	
	}

}
