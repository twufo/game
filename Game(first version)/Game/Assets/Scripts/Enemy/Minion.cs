using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Enemy {

	// Use this for initialization
	public override void Start () {
		base.Start ();

	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();

	}

	public override void Hit (float damage)
	{


	}


	public override void OnTriggerEnter (Collider other)
	{
		base.OnTriggerEnter (other);


	}

	protected override void Death ()
	{
		base.Death ();


	}

}
