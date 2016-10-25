using UnityEngine;
using System.Collections;

public class ColorChangingRepository : MonoBehaviour {

	public Material[] materials;
	public Renderer rend;

	private int index = 1;

	GameObject repository;
	RepositoryHealth repositoryHealth;

	// Use this for initialization
	void Awake () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;

		repository = GameObject.FindGameObjectWithTag ("Player");
		repositoryHealth = repository.GetComponent<RepositoryHealth> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (repositoryHealth.currentHealth <= 1000 && repositoryHealth.currentHealth > 500) {
			index = 1; // Vert
			rend.sharedMaterial = materials [index - 1];
		} else if (repositoryHealth.currentHealth < 500 && repositoryHealth.currentHealth > 200) {
			index = 2; // Jaune
			rend.sharedMaterial = materials [index - 1];
		} else if (repositoryHealth.currentHealth <= 200) {
			index = 3; //Rouge
			rend.sharedMaterial = materials [index - 1];
		} else if (repositoryHealth.currentHealth == 0) {
			index = 4;
			rend.sharedMaterial = materials [index - 1];
		}
	}
}
