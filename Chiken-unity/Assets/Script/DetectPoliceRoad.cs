using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPoliceRoad : MonoBehaviour {

	public GameObject RoadAlertBlink;

	void Start(){
		RoadAlertBlink.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D target){
		if (gameObject != null) {
			if (target.gameObject.tag == "PoliceRoad") {
				RoadAlertBlink.SetActive(true);
				StartCoroutine (DisableBlink (3f));
				print ("PoliceRoadHit");
			}

		}
	}
	IEnumerator DisableBlink(float delay){
		yield return new WaitForSeconds(delay);
		RoadAlertBlink.SetActive(false);
	}
}
