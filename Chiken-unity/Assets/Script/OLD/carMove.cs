using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMove : MonoBehaviour {

	private Rigidbody2D theRB;
	public Vector2 carSpeed;


	private float carSpeedRnd;
	private bool RTL;

	private AudioSource audioSource; 
	public AudioClip carSound;
	private bool soundOn = false;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		carSpeedRnd = rndCarSpeed ();
		if (theRB.transform.position.x < -100) {
			transform.localRotation = Quaternion.Euler (0, 180, 0);
			RTL = false;
		} else {
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			RTL = true;
		}

	}

	void FixedUpdate () {
		if (RTL) {
			theRB.velocity = new Vector2 (-carSpeedRnd, 0f);
			if(theRB.position.x < -450)
				Destroy (gameObject);
		} else {
			theRB.velocity = new Vector2 (carSpeedRnd, 0f);
			if(theRB.position.x > 450)
				Destroy (gameObject);
		}
		/*
		if (theRB.position.x > -240 && theRB.position.x < 240) {
			soundOn = true;
			PlaySound ();
		} else {
			StopSound ();
		}
		*/
	}
	float rndCarSpeed(){

		return Random.Range (carSpeed.x, carSpeed.y);

	}
	void OnBecameInvisible(){
		soundOn = false;
		Destroy (gameObject);
	}
	void PlaySound(){
		if (!soundOn) {
			audioSource.clip = carSound;
			audioSource.Play ();
		}
	}

	void StopSound(){
		audioSource.Stop ();
		soundOn = false;
	}
	private void OnBecameVisible() {
		PlaySound ();
	}
}
