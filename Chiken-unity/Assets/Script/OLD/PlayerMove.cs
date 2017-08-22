using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float speed = 10f;
	public Vector2 velocity = Vector2.zero;


	private Rigidbody2D theRB;

	void Awake(){
		theRB = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		theRB.velocity = velocity;

		/*
		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs (theRB.velocity.x);

		if (Input.GetKey ("up")) {
			if (absVelX < maxVelocity)
				forceX = speed;
		
		}
		*/
	}


}
