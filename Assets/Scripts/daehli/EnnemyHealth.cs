using UnityEngine;
using System.Collections;

public class EnnemyHealth : MonoBehaviour {

	public int startingHealth = 100; // Faire de l'héritage
	public int currentHealth;
	public int scoreValue = 100; // nombre de ligne de code
	public int scoreResource = 100;




	bool isDead;
	// Constructeur 
	void Awake (){
		currentHealth = startingHealth;
	}
			
	// Update is called once per frame
	void Update () {
	
	}


	public void TakeDamage (int amount)
	{
		if(isDead)
			return;

		currentHealth -= amount;


		if(currentHealth <= 0)
		{
			Death ();
		}
	}

	public void ExploseOnContact(){ 
		Death ();
	}


	void Death ()
	{
		isDead = true;
		ScoreManager.score += scoreValue;
		RessourcesManager.ressources += scoreResource;
		Destroy (gameObject);

		// capsuleCollider.isTrigger = true;

	}
		
}
