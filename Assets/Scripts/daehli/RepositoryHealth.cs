using UnityEngine;
using UnityEngine.UI; // pour Avoir une interaction avec les objet UI
using System.Collections;

public class RepositoryHealth : MonoBehaviour {

	public int startingHealth = 1000;
	public int currentHealth;

	bool isDead;
	bool damaged;

	// Comme un constructeur
	void Awake(){
		currentHealth = startingHealth;

	}

	
	// Update is called once per frame
	void Update () {

		if (damaged) {
			//reçoit du dommage
		} else {
			// Ne reçoit pas de dommage	
		}

		damaged = false;
	
	}

	// Quand C'est public les autrs Scripts peuvent l'appeler

	public void TakeDamage (int amount)
	{
		// Mettre le dommage a vrai
		damaged = true;

		// Combien de vie doit t'il perdre
		currentHealth -= amount;

		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
		}
	}

	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;

		Destroy (gameObject);

	}      
		
}
