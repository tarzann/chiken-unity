using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour {

	public bool actionButton;
	public float absValX = 0f;
	public float absValY = 0f;
	public bool standing;
	public float standingThreshold = 1;

	private Rigidbody2D body2d;

	void Awake(){

		body2d = GetComponent<Rigidbody2D> ();
	}

	
	// Update is called once per frame
	void Update () {
	
		actionButton = Input.anyKeyDown;

		if (actionButton) {
			print (actionButton);

		}

	}

	void FixedUpdate(){

		absValX = System.Math.Abs (body2d.velocity.x);
		absValY = System.Math.Abs (body2d.velocity.y);

		standing = absValY <= standingThreshold;

	}
}
