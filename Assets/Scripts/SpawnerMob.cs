using UnityEngine;
using System.Collections;

public class SpawnerMob : MonoBehaviour {

    public GameObject groundEnemy;
	public GameObject flyingEnemy;

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

	void spawnEnemy(){
		int random = (int)Random.Range (0f, 100f);

        if (random < groundChance)
			Instantiate (groundEnemy, this.transform.position, Quaternion.identity);
		else if(random < flyingChance + groundChance)
			Instantiate (flyingEnemy, this.transform.position, Quaternion.identity);

        monstersToSpawn--;
	}

    public IEnumerator Wave() {
        while(monstersToSpawn > 0) {
            spawnEnemy();
            yield return new WaitForSeconds(Random.Range(minTimerSpawner, maxTimerSpawner));
        }
    }
}
