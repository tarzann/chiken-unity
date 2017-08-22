using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour {


	public float offset = 16f;


	private bool offscreen;
	public bool RTL;
	private float offscreenX = 0f;
	private Rigidbody2D body2d;


	// Use this for initialization
	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
	}

	void Start(){
		offscreenX = (Screen.width / PixelPerfectCamera.pixelToUnits) / 2 + offset;
		if (RTL)
			offscreenX = 600;
		else
			offscreenX = -600;
//		print ("offscreenX = " + offscreenX);
	}
	
	// Update is called once per frame
	void Update () {
		var posX = transform.position.x;
		var dirX = body2d.velocity.x;
		if (RTL) {
			if (Mathf.Abs (posX) > offscreenX) {
				if (dirX < 0 && posX < -offscreenX) {
					offscreen = true;
				} else if (dirX > 0 && posX > offscreenX) {
					offscreen = true;
				}
			} else {
				offscreen = false;
			}

			if (offscreen) {
				onOutOfBounds ();
			}
		} else {
			if (Mathf.Abs (posX) > -offscreenX) {
					offscreen = true;
						} else {
				offscreen = false;
			}

			if (offscreen) {
				onOutOfBounds ();
			}
		}
	}

	public void onOutOfBounds(){
		offscreen = false;
		//GameObjectUtil.Destroy (gameObject);
		Destroy (gameObject);
	} 
}
