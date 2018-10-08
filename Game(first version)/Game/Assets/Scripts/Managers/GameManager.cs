using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	private static GameManager gameMan;


	public LayerMask clickMask;




	int activeEnemiesCount;

	bool outOfWaves_flag;
	bool castleDied_flag;

	void Awake()
	{
		if (gameMan == null) {
			gameMan = this;
		} else {
			Destroy (gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		outOfWaves_flag = false;
		castleDied_flag = false;
		activeEnemiesCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		CheckForInput ();

		CheckForGameOver ();
	
	}


	public static void CastleDied()
	{
		gameMan.castleDied_flag = true;
	}

	public static void OutOfWaves()
	{
		gameMan.outOfWaves_flag = true;
	}

	public static void AddEnemy(Enemy e)
	{
		gameMan.activeEnemiesCount += 1;
	}

	public static void RemoveEnemy(Enemy e)
	{
		gameMan.activeEnemiesCount -= 1;


	}

	void CheckForGameOver()
	{
	if (castleDied_flag) {
			LoadLevel ("Main Menu");
		}
	}

	void CheckForInput()
	{
		


	}


	

	// Level Loading
	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void LoadLevel(int index)
	{
		SceneManager.LoadScene (index);
	}


}
