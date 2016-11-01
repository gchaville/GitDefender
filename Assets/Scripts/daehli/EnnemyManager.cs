using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnnemyManager : MonoBehaviour {


	public RepositoryHealth repositoryHealth;
	public List<GameObject> Ennemy;
	public float spawnTime = 10f;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!IsInvoking()){
			int random = Random.Range (0, 10);
			if (random % 2 == 0) {
				Invoke ("Spawn", 0f);
			}
			
		}
	
	}

	void Spawn(){

		int random =  Random.Range (0, Ennemy.Count);

		if (repositoryHealth.currentHealth <= 0) {

			// exit la fonction
			return;
		}

		Instantiate (Ennemy[random], spawnPoints [0].position, spawnPoints [0].rotation);
		
	}
}
