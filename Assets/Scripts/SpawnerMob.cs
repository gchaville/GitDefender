using UnityEngine;
using System.Collections;

public class SpawnerMob : MonoBehaviour {

	public GameObject groundEnemy;

	public GameObject flyingEnemy;

	private float spawnTimer;
	private float maxTimerSpawner = 5f;
	private float minTimerSpawner = 1f;

	void Start () {
		spawnTimer = Random.Range (minTimerSpawner, maxTimerSpawner);
	}

	void Update () {
		if (spawnTimer > 0) {
			spawnTimer -= Time.deltaTime;
		} else {
			spawnEnemy ();
		}
	}

	void spawnEnemy(){
		int random = (int)Random.Range (0f, 2f);
		if (random == 1) {
			GameObject toInstantiate = Instantiate (groundEnemy, this.transform.position, Quaternion.identity) as GameObject;
		} else {
			GameObject toInstantiate = Instantiate (flyingEnemy, this.transform.position, Quaternion.identity) as GameObject;
		}
		spawnTimer = Random.Range (minTimerSpawner, maxTimerSpawner);
	}
}
