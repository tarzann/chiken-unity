using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presentHit : MonoBehaviour {

	public ParticleSystem presentBoom;
	// Use this for initialization
	void Start () {
		presentBoom.Stop ();
		presentBoom.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D target){
		if (gameObject != null) {
			if (target.gameObject.tag == "Player") {
				PlayerPrefs.SetInt("present",0); // 0  = true;
				print("present after hit = " + PlayerPrefs.GetInt("present"));
				presentBoom.Play ();
				presentBoom.enableEmission = true;
				iTween.FadeTo (gameObject, 0f, 0.5f);
				Destroy (gameObject, 0.7f);

			}

		}
	}
}
