using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleCreator : MonoBehaviour {

	public GameObject[] bicycle;
	public Transform bicyclePointRTL;
	public Transform bicyclePointLTR;
	private Transform thisObj;

	public bool RTL;

	public float spawnDelay;
	private float spawnCounter;

	private int rnd;

	// Use this for initialization
	void Start () {
		//thisObj.GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update () {
		spawnCounter -= Time.deltaTime;

		if (spawnCounter <= 0) {
			bicycle [0].gameObject.tag = "Car";
			if (RTL) {
				//transform.localRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (bicycle[0], bicyclePointRTL.position, bicyclePointRTL.rotation);
				bicycle [0].transform.SetParent(thisObj,true);
				spawnCounter = spawnDelay;
			} else {
				//transform.localRotation = Quaternion.Euler (0, 0, 0);
				Instantiate (bicycle[0], bicyclePointLTR.position, bicyclePointLTR.rotation);
				bicycle [0].transform.SetParent(thisObj,true);
				spawnCounter = spawnDelay;
			}

		}


	}


		
}
