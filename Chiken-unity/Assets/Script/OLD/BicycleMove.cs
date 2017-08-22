using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleMove : MonoBehaviour {

	private Rigidbody2D theRB;
	public Vector2 speed;


	private float speedRnd;
	public bool RTL;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D> ();
		speedRnd = rndBicycleSpeed ();
	}

	// Update is called once per frame
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

	float rndBicycleSpeed(){

		return Random.Range (speed.x, speed.y);

	}
	void OnBecameInvisible(){

		Destroy (gameObject);
	}
}
