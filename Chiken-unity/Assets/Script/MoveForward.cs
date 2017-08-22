using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

	public float speed = 50f;

	private Rigidbody2D body2d;
	private InputState inputState;
	private Transform transform;
	private Transform transformTo;

	public Transform target;


	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
		transform = GetComponent<Transform> ();
		inputState = GetComponent<InputState> ();
	}
	
	// Update is called once per frame
	void Update () {

		float step = speed * Time.deltaTime;


		if (inputState.standing) {

			if (inputState.actionButton) {
				//body2d.velocity = new Vector2 (0f, speed);
				//transformTo.position = new Vector3(transform.position.x,transform.position.y+53.3f,transform.position.z);
//				transformTo.position = new Vector3(0f,53f,0f);
				//StartCoroutine (MoveFunction());
				print(transform.position.y);

				//transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,53.3f,0f), step);
				//target.position = new Vector3(0,53.3f,0);
				//transform.position = Vector3.MoveTowards(transform.position,target.position,step);
			}
		}
	}

	IEnumerator MoveFunction(){
		float timeSinceStarted = 0f;
		while (true)
		{
			timeSinceStarted += Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, transformTo.position, timeSinceStarted);

			// If the object has arrived, stop the coroutine
			if (transform.position == transformTo.position){
				yield break;
			}

			// Otherwise, continue next frame
			yield return null;
		}
	}
}
