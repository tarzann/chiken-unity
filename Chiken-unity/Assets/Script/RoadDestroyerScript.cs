using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDestroyerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D target){
		if (gameObject != null) {
			if (target.gameObject.tag == "Road" || target.gameObject.tag == "PoliceRoad") {
				foreach (Transform child in target.transform) {
					GameObject.Destroy(child.gameObject);
				}

			}

		}
	}
}
