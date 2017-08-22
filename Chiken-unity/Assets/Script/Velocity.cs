using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour {

	public Transform other;
	public float speed = 160f;
	private Vector3 desiredVelocity;
	private float lastSqrMag;
	private Rigidbody2D rigidbody;
	private bool actionButton;
	private float sqrMag;



	public float closeDistance = 3.0F;


	void Start(){
		rigidbody = GetComponent<Rigidbody2D> ();

		Vector3 directionalVector = (other.position - transform.position).normalized * speed;

		// reset lastSqrMag
		lastSqrMag = Mathf.Infinity;

		// apply to rigidbody velocity
		desiredVelocity = directionalVector;
	}

	void Update() {
		actionButton = Input.anyKeyDown;

		if (other) {
			Vector3 offset = other.position - transform.position;
			float sqrLen = offset.sqrMagnitude;
			if (sqrLen < closeDistance * closeDistance) {
				//print ("The other transform is close to me!");
				desiredVelocity = Vector3.zero;
			}

		}
		if (actionButton) {
			print ("click");
			other.position = new Vector3 (other.position.x, other.position.y + 53f, other.position.z);
			Vector3 directionalVector = (other.position - transform.position).normalized * speed;
			lastSqrMag = Mathf.Infinity;
			desiredVelocity = directionalVector;
		}
	}

	void FixedUpdate() {
		//if(moveOn)
		rigidbody.velocity = desiredVelocity;

	}
}