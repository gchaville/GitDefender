using UnityEngine;
using System.Collections;
using System;

public class GithubAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage;

	GameObject Ennemy;
	EnnemyHealth ennemyHealth;
	Transform currentPositionGithub;
	Transform EnnemyPosition;

	bool EnnemyInRange;
	float timer;


	// Use this for initialization
	void Awake () {

		Ennemy = GameObject.FindGameObjectWithTag ("Ennemy");
		ennemyHealth = Ennemy.GetComponent<EnnemyHealth> ();
		EnnemyPosition = Ennemy.transform;
		currentPositionGithub = gameObject.transform;
	
	}

	// Update is called once per frame
	void Update () {
		if (Ennemy != null) {
			timer += Time.deltaTime;

			if (System.Math.Abs(currentPositionGithub.position.x - EnnemyPosition.position.x) <= 1.5f) {
				EnnemyInRange = true;
			}


			if(timer >= timeBetweenAttacks && EnnemyInRange/* && enemyHealth.currentHealth > 0*/)
			{
				Attack ();
			}

			EnnemyInRange = false;
		}
	
	}

	
	void Attack(){
		timer = 0f;
		if (ennemyHealth.currentHealth > 0 && EnnemyInRange) {
			ennemyHealth.TakeDamage(attackDamage);
		}
	}
}