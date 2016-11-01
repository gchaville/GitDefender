using UnityEngine;
using System.Collections;

public class SpawnerMob : MonoBehaviour {

    public GameObject groundEnemy;
	public GameObject flyingEnemy;
	public GameObject speedEnemy;

	public int direction;
	private Vector3 dirVector;

	private float maxTimerSpawner = 4f;
	private float minTimerSpawner = 1f;

	public bool isMenuSpawner;
	private float chronoMenu;

    private int groundChance,
                flyingChance,
                speedChance,
                monstersToSpawn;

    public void SetWaveInfos(int ground, int flying, int speed, int num) {
        groundChance = ground;
        flyingChance = flying;
        speedChance = speed;
        monstersToSpawn = num;
        GameManager.instance.monstersLeft += num;
    }

	void Awake(){
		if (direction == 1) {
			dirVector = Vector3.left;
		} else
			dirVector = Vector3.right;
		if (!isMenuSpawner)
			return;
		chronoMenu = Random.Range (1f, 2f);
	}

	void Update(){
		if (!isMenuSpawner)
			return;
		if (chronoMenu > 0) {
			chronoMenu -= Time.deltaTime;
		} else {
			spawnMenuEnemy ();
			chronoMenu = Random.Range (1f, 2f);
		}
	}

	void spawnEnemy(){
		int random = (int)Random.Range (0f, 100f);
		GameObject toInstantiate;
		if (random < groundChance) {
			toInstantiate = Instantiate (groundEnemy, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<Enemy> ().setdirection (dirVector);
		} else if (random < flyingChance + groundChance) {
			toInstantiate = Instantiate (flyingEnemy, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<Enemy> ().setdirection (dirVector);
		} else {
			toInstantiate = Instantiate (speedEnemy, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<Enemy> ().setdirection (dirVector);
		}
        monstersToSpawn--;
	}

	void spawnMenuEnemy(){
		int random = (int)Random.Range (0f, 100f);
		GameObject toInstantiate;
		if (random < 50) {
			toInstantiate = Instantiate (groundEnemy, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<Enemy> ().setdirection (dirVector);
			Destroy (toInstantiate, 15f);
		} else if (random < 75) {
			toInstantiate = Instantiate (flyingEnemy, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<Enemy> ().setdirection (dirVector);
			Destroy (toInstantiate, 15f);
		} else {
			toInstantiate = Instantiate (speedEnemy, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<Enemy> ().setdirection (dirVector);
			Destroy (toInstantiate, 15f);
		}
	}

    public IEnumerator Wave() {
        while(monstersToSpawn > 0) {
            spawnEnemy();
            yield return new WaitForSeconds(Random.Range(minTimerSpawner, maxTimerSpawner));
        }
    }
}
