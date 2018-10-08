using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENTITY_STATE
{
	ALIVE,
	DEAD
}

public abstract class Entity : MonoBehaviour {

	protected ENTITY_STATE state;
	public float startHealth;
	protected float health;


	// Use this for initialization
	public virtual void Start () {
		state = ENTITY_STATE.ALIVE;
		health = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public abstract void Hit (float damage);

}
