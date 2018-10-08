using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Entity {

	// Use this for initialization
	public override void Start () {
		base.Start ();
		health = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Hit(float damage)
	{
		health -= damage;

		if (health <= 0) {
			state = ENTITY_STATE.DEAD;
			Debug.Log ("CASTLE DESTROYED");
			GameManager.CastleDied ();
		}

	}
}
