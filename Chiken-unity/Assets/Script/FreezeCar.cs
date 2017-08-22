using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCar : MonoBehaviour {

	public bool freezeOn = false;
	private Rigidbody2D body2d;
	float currentVelocityX;

	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentVelocityX = body2d.velocity.x;
		if (freezeOn) {
			body2d.velocity = body2d.velocity * 0.9f;
			//StartCoroutine (FreezeNow ());
		}
	}

	IEnumerator FreezeNow(){
		print (currentVelocityX);

			while(currentVelocityX < 0){
				currentVelocityX += 10;
				body2d.velocity = new Vector2 (currentVelocityX, 0);
				//yield return new WaitForSeconds (0.1f);
			}
		yield return new WaitForSeconds (0.1f);
	}


}
