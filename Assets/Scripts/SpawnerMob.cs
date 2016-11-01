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
			dirVector = Vector3.right;
		} else
			dirVector = Vector3.left;
	}

	void spawnEnemy(){
		int random = (int)Random.Range (0f, 100f);
		GameObject toInstantiate;
		if (random < groundChance) {
			toInstantiate = Instantiate (groundEnemy, this.transform.position, Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<Enemy> ().setdirection (dirVector);
		} else if (random < flyingChance + groundChance) {
			toInstantiate = Instantiate (flyingEnemy, this.transform.position, Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<Enemy> ().setdirection (dirVector);
		} else {
			toInstantiate = Instantiate (speedEnemy, this.transform.position, Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<Enemy> ().setdirection (dirVector);
		}
        monstersToSpawn--;
	}

    public IEnumerator Wave() {
        while(monstersToSpawn > 0) {
            spawnEnemy();
            yield return new WaitForSeconds(Random.Range(minTimerSpawner, maxTimerSpawner));
        }
    }
}
