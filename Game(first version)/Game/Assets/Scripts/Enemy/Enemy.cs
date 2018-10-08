using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class Enemy : Entity {

	public float speed;
	protected GameObject castle;
	protected NavMeshAgent agent;
	protected Path path;
	protected Transform currentTarget;
	protected int pathIndex;

	// Use this for initialization
	public override void Start () {
		base.Start ();
		castle = GameObject.FindGameObjectWithTag ("Castle");
		agent = GetComponent<NavMeshAgent> ();
		pathIndex = 0;
		agent.speed = speed;
		GameManager.AddEnemy (this);
	}

	// Update is called once per frame
	public virtual void Update () {

		if (path != null) {
			currentTarget = path.pathPoints [pathIndex].transform;

			if (Vector3.Distance (currentTarget.transform.position, transform.position) < 1.0f) {
				pathIndex++;
				if (pathIndex >= path.pathPoints.Count) {
					currentTarget = castle.transform;
					path = null;
				}
			}

		}

		agent.SetDestination (currentTarget.position);
	}

	public void SetPath(Path p)
	{
		path = p;
	}


		
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Castle") {

			Castle c = other.gameObject.GetComponent < Castle> ();

			c.Hit (25);
			Death ();
		}
	}

	protected virtual void Death()
	{
		GameManager.RemoveEnemy (this);
		Destroy (gameObject);
	}

}
