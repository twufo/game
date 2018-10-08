using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour {

	public Wave waveRef;

	float timer;
	int enemiesToSpawn;


	// Use this for initialization
	void Start () {
		timer = waveRef.spawnInterval;
		enemiesToSpawn = waveRef.totalEnemies;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			timer = waveRef.spawnInterval;

			GameObject e = waveRef.enemyPrefab;
			EnemySpawner spawner = waveRef.spawner;

			spawner.SpawnEnemy (e);

			enemiesToSpawn--;

			if (enemiesToSpawn <= 0) {
				WaveManager.WaveComplete (this);
				Destroy (gameObject);
			}
		}
	}
}
