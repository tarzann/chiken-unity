using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LownmonwerMove : MonoBehaviour {

	private Rigidbody2D theRB;
	public Vector2 speed;


	private float speedRnd;
	private bool RTL;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D> ();
		speedRnd = rndSpeed ();
		if (theRB.transform.position.x < -100) {
			transform.localRotation = Quaternion.Euler (0, 180, 0);
			RTL = false;
		} else {
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			RTL = true;
		}

	}

	// UpFdate is called once per frame
	void FixedUpdate () {
		if (RTL) {
			theRB.velocity = new Vector2 (-speedRnd, 0f);
			if(theRB.position.x < -450)
				Destroy (gameObject);
		} else {
			theRB.velocity = new Vector2 (speedRnd, 0f);
			if(theRB.position.x > 450)
				Destroy (gameObject);
		}
	}

	float rndSpeed(){

		return Random.Range (speed.x, speed.y);

	}
	void OnBecameInvisible(){

		Destroy (gameObject);
	}
}
