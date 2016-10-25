using UnityEngine;
using System.Collections;

public class EnnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	// Faire un critical avec un fonction

	GameObject repository;
	RepositoryHealth repositoryHealth;
	Transform repositoryPosition;
	Transform currentPositionEnnemy;

	float timer;
	bool repositortInRange;

	void Awake(){
		repository = GameObject.FindGameObjectWithTag ("Player"); // Je peut le changer 
		repositoryHealth = repository.GetComponent<RepositoryHealth> ();
		repositoryPosition = repository.transform;
		currentPositionEnnemy = gameObject.transform;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		currentPositionEnnemy = gameObject.transform;
		Debug.Log (currentPositionEnnemy.position - repositoryPosition.position);

		if ((currentPositionEnnemy.position.x - repositoryPosition.position.x) <= 1.5f) {
			repositortInRange = true;
		}

		if(timer >= timeBetweenAttacks && repositortInRange/* && enemyHealth.currentHealth > 0*/)
		{
			Attack ();
		}

		repositortInRange = false;
			
	}

	void Attack(){
		timer = 0f;
		if (repositoryHealth.currentHealth > 0) {
			repositoryHealth.TakeDamage (attackDamage);
		}
	}
}
