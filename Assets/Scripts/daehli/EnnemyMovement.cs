using UnityEngine;
using System.Collections;

public class EnnemyMovement : MonoBehaviour {

	Transform repository; // Prend la position du Repository
	NavMeshAgent nav; // AI qui ce dirige vers le repository


	void Awake()
	{
		repository = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();

	}

	// Update is called once per frame
	void Update () {
		nav.SetDestination (repository.position);
	}
}
