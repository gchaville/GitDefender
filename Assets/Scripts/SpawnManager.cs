using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public GameObject[] spawners;
    private List<SpawnerMob> spawns = new List<SpawnerMob>();

    private int difficulty;
    private int ennemiesToSpawn;

    private int groundChance,
                flyingChance,
                speedChance;

    void Start() {
        groundChance = 100;
        flyingChance = 0;
        speedChance = 0;

        for (int i = 0; i < spawners.Length; i++)
            spawns.Add(spawners[i].GetComponent<SpawnerMob>());
    }
    
    public void StartNewWave(int wave) {
        Debug.Log("Wave " + wave);

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
