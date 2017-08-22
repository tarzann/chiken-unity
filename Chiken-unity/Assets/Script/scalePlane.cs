using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalePlane : MonoBehaviour {


	public bool isPlane;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlane) {
			if (transform.position.x > 250 && transform.position.x < 270){
				transform.localScale = new Vector3(-1.5f,1.5f,0);

			}
			if (transform.position.x > 270) {
				print ("transform.localScale.x = " + transform.localScale.x);
				while (Mathf.Abs(transform.localScale.x) > 1) {
					float cuurentScale = Mathf.Abs(transform.localScale.x);
					cuurentScale = cuurentScale - (cuurentScale * 0.1f);
					transform.localScale = new Vector3(-cuurentScale,cuurentScale,0);
				}

			}


		}
	}
}
