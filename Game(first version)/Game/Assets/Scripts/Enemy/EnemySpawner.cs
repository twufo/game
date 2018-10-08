using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Path[] enemyPaths;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void SpawnEnemy(GameObject prefab)
	{
		GameObject obj = Instantiate (prefab, transform.position, prefab.transform.rotation);

		Enemy e = obj.GetComponent<Enemy> ();

		int randInt = Random.Range (0, enemyPaths.Length);

		e.SetPath (enemyPaths [randInt]);
	}



}
