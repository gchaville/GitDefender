using UnityEngine;
using UnityEngine.UI; // pour Avoir une interaction avec les objet UI
using System.Collections;

public class RepositoryHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	TextMesh text;
	Animator anim;

	bool isDead;
	bool damaged;

	// Comme un constructeur
	void Awake(){
		currentHealth = startingHealth;
		text = gameObject.GetComponentInChildren<TextMesh>();
		anim = gameObject.GetComponentInChildren<Animator> (); 
		text.text = "" + startingHealth + "\n--------\n"+ currentHealth;

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

	// Quand C'est public les autres Scripts peuvent l'appeler

	public void TakeDamage (int amount)
	{
		// Mettre le dommage a vrai
		damaged = true;

		// Combien de vie doit t'il perdre
		currentHealth -= amount;

		text.text = "" + startingHealth + "\n--------\n"+ currentHealth;

		// Animation de la base de donnée

		anim.SetInteger ("lifes", currentHealth);

		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
			text.text += "You are a Looser !!";
		}
	}

	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;

		Destroy (gameObject);

	}      
		
}
