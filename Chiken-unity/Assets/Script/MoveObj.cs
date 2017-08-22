using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour {

	public Rigidbody2D body2d;

	public GameObject player;
	public Vector3 oldPos;
	public Vector3 newPos;
	public bool moveTrue;
	public bool actionButton;
	public float moveSpeed = 0.1f;
	public float step = 200f;

	public Animator animator;



	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		SetNewPos ();
	}
	
	// Update is called once per frame
	void Update () {
		actionButton = Input.anyKeyDown;

		if (actionButton && !moveTrue) {
			SetNewPos ();
			oldPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			//StartCoroutine(Move2Pos ());
			while(Mathf.Abs (oldPos.y) != Mathf.Abs (newPos.y)) {
				player.transform.position = Vector3.MoveTowards (oldPos, newPos, Time.deltaTime * step);
				//	animator.SetInteger ("AnimationStat", 1);
				actionButton = false;
				moveTrue = false;
			}
			moveTrue = true;

		}

	}
	void SetNewPos(){
		moveTrue = true;
		var renderer = GetComponent<SpriteRenderer> ();
		var playerSize = renderer.bounds.size;
		newPos = new Vector3 (player.transform.position.x, player.transform.position.y + playerSize.y, player.transform.position.z);
		print ("newPos =  " + newPos);
	}
		


	IEnumerator Move2Pos() {
		yield return new WaitForSeconds (moveSpeed);

		print ("oldPos = " + oldPos);
		print ("newPos =  " + newPos);
		print ("moveTrue = " + moveTrue);
		if (Mathf.Abs(oldPos.y) != Mathf.Abs(newPos.y) && moveTrue) {
			oldPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			player.transform.position = Vector3.MoveTowards (oldPos, newPos, Time.deltaTime * step);
		//	animator.SetInteger ("AnimationStat", 1);
			StartCoroutine(Move2Pos ());
			actionButton = false;
		} else {
			moveTrue = false;
		//	animator.SetInteger ("AnimationStat", 0);
			StopCoroutine(Move2Pos ());
		}
		//
	}
}
