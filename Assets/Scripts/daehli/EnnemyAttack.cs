using UnityEngine;
using System.Collections;

public class EnnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 100;
	// Faire un critical avec un fonction

	GameObject repository;
	RepositoryHealth repositoryHealth;
	EnnemyHealth ennemyHealth;
	Transform repositoryPosition;
	Transform currentPositionEnnemy;

	float timer;
	bool repositortInRange;

	void Awake(){
		repository = GameObject.FindGameObjectWithTag ("Player"); // Je peut le changer 
		repositoryHealth = repository.GetComponent<RepositoryHealth> ();
		repositoryPosition = repository.transform;
		currentPositionEnnemy = gameObject.transform;
		ennemyHealth = gameObject.GetComponent<EnnemyHealth> ();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		currentPositionEnnemy = gameObject.transform;
		if (currentPositionEnnemy != null) {

			if ((currentPositionEnnemy.position.x - repositoryPosition.position.x) <= 1.5f) {
				repositortInRange = true;
			}

			if (timer >= timeBetweenAttacks && repositortInRange/* && enemyHealth.currentHealth > 0*/) {
				Attack ();
			}

			repositortInRange = false;
		} else
			return;
			
	}

	void Attack(){
		timer = 0f;
		if (repositoryHealth.currentHealth > 0) {
			repositoryHealth.TakeDamage(attackDamage);
			//ennemyHealth.ExploseOnContact ();
		}
	}
}
