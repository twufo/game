using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wave
{
	public float spawnTimeAfterStart;
	public GameObject enemyPrefab;
	public EnemySpawner spawner;
	public int totalEnemies;
	public float spawnInterval;
}

public class WaveManager : MonoBehaviour {

	private static WaveManager waveMan;

	public GameObject spawnWavePrefab;
	public List<Wave> waveList = new List<Wave>();

	private Wave nextWave;

	GameManager gameMan;

	int waveCount;

	void Awake()
	{
		if (waveMan == null) {
			waveMan = this;
		} else {
			Destroy (waveMan);
		}
	}

	// Use this for initialization
	void Start () {
		gameMan = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();

		waveCount = waveList.Count;
		foreach (Wave w in waveList) {
			StartCoroutine (CreateSpawnWave (w));
		}
	}

	IEnumerator CreateSpawnWave(Wave waveRef)
	{
		yield return new WaitForSeconds (waveRef.spawnTimeAfterStart);

		GameObject gObj = Instantiate (spawnWavePrefab, transform);

		SpawnWave sw = gObj.GetComponent<SpawnWave> ();

		sw.waveRef = waveRef;


	}

	public static void WaveComplete(SpawnWave w)
	{
		waveMan.waveCount--;

		if (waveMan.waveCount <= 0) {
			GameManager.OutOfWaves ();
		}
	}
}
