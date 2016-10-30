using UnityEngine;
using System.Collections;

public class EnnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 100;
	// Faire un critical avec un fonction

	GameObject repository;
	RepositoryHealth repositoryHealth;
	EnnemyHealth ennemyHealth;

	float timer;
	bool repositortInRange;

	void Awake(){
		repository = GameObject.FindGameObjectWithTag ("Player"); // Je peut le changer 
		repositoryHealth = repository.GetComponent<RepositoryHealth> ();
		ennemyHealth = gameObject.GetComponent<EnnemyHealth> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void Attack(){
		timer = 0f;
		if (repositoryHealth.currentHealth > 0) {
			repositoryHealth.TakeDamage(attackDamage);
			ennemyHealth.ExploseOnContact ();
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			Attack ();
		}
	}
}
