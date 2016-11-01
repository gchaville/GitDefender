using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

	public List<GameObject> spawners = new List<GameObject>();
    private List<SpawnerMob> spawns = new List<SpawnerMob>();


    private int difficulty;
    private int ennemiesToSpawn;

    private int groundChance,
                flyingChance,
                speedChance;

    void Start() {
		GameObject toInstantiante = Instantiate(Resources.Load ("SpawnerGestionnary") ,new Vector3(8.7f,0f,-10f), Quaternion.identity) as GameObject;
		for(int i = 0; i <toInstantiante.transform.childCount; i++){
			spawners.Add(toInstantiante.transform.GetChild (i).gameObject);
		}
        groundChance = 100;
        flyingChance = 0;
        speedChance = 0;

		for (int i = 0; i < spawners.Count; i++)
            spawns.Add(spawners[i].GetComponent<SpawnerMob>());
    }
    
    public void StartNewWave(int wave) {
        UpgradeDifficulty(wave);

        Debug.Log(groundChance + " " + flyingChance + " " + speedChance + " " + ennemiesToSpawn);

        spawns[0].SetWaveInfos(groundChance, flyingChance, speedChance, ennemiesToSpawn);
        spawns[1].SetWaveInfos(groundChance, flyingChance, speedChance, ennemiesToSpawn);

      	if (wave > 4) {
            spawns[2].SetWaveInfos(groundChance, flyingChance, speedChance, ennemiesToSpawn);
            spawns[3].SetWaveInfos(groundChance, flyingChance, speedChance, ennemiesToSpawn);
        }

        if (wave > 9) {
            spawns[4].SetWaveInfos(groundChance, flyingChance, speedChance, ennemiesToSpawn);
            spawns[5].SetWaveInfos(groundChance, flyingChance, speedChance, ennemiesToSpawn);
        }
			
        foreach (SpawnerMob s in spawns)
            StartCoroutine(s.Wave());
    }

    void UpgradeDifficulty(int wave) {
        if(ennemiesToSpawn < 50)
            ennemiesToSpawn += 1;

        if(wave > 2 && groundChance > 40 && flyingChance < 30) {
            flyingChance += 5;
            groundChance -= 5;
        }

        if(wave > 4 && groundChance > 40 && speedChance < 30) {
            speedChance += 5;
            groundChance -= 5;
        }      
    }
}
