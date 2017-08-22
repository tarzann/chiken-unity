using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantVelocity : MonoBehaviour {

	public Vector2 velocity = Vector2.zero;
	public bool RTL;
	public float stepTime = 1f;
	public bool active = true;
	private float timeElepse = 0f;
	private float startTime;
	private float rndSpeed;
	private Vector2 hitVelocity1 = new Vector2(70f,0f);
	private Vector2 hitVelocity2 = new Vector2(50f,0f);


	private AudioSource audioSource; 
	public AudioClip carSound;
	private bool soundOn = false;

	private Rigidbody2D body2d;

	// Use this for initialization
	void Awake () {
		
		body2d = GetComponent<Rigidbody2D> ();
		rndSpeed = Random.Range (velocity.x, velocity.y);

	}

	void Start(){
		audioSource = GetComponent<AudioSource> ();

	}
	void OnTriggerEnter2D(Collider2D target){
		
		if (gameObject != null) {
			if (target.gameObject.tag == "Car") {
				var newBody2d = target.gameObject.GetComponent<Rigidbody2D> ();
				if (RTL) {
					newBody2d.velocity = -hitVelocity2;
					body2d.velocity = -hitVelocity1;
				} else {
					newBody2d.velocity = hitVelocity2;
					body2d.velocity = hitVelocity1;
				}
			
				active = false;
			}
		}

	}
	private void OnBecameVisible() {
		PlaySound ();
	}
	void FixedUpdate () {
		if (active) {
			body2d.velocity  = new Vector2(rndSpeed,0);
			timeElepse = Time.time - Time.deltaTime;
			if (timeElepse >= stepTime) {
				active = false;

			}

		}
	}

	void PlaySound(){
		if (soundOn && carSound) {
			audioSource.clip = carSound;
			audioSource.Play ();
		}
	}

	void StopSound(){
		if (soundOn && carSound) {
			audioSource.Stop ();
			soundOn = false;
		}
	}
}
