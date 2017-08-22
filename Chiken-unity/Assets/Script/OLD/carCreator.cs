using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCreator : MonoBehaviour {

	public GameObject[] car;
	public Transform carPointRTL;
	public Transform carPointLTR;
	public bool RTL;
	public bool active;

	public float carSpawnDelay;
	private float spawnCounter;

	private int rndCar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			spawnCounter -= Time.deltaTime;

			if (spawnCounter <= 0) {
				rndCar = GetRandomCar ();
				if (RTL) {
					car [rndCar].gameObject.tag = "Road";
					Instantiate (car [rndCar], carPointRTL.position, carPointRTL.rotation);
					spawnCounter = carSpawnDelay;
				} else {
					car [rndCar].gameObject.tag = "Road";
					Instantiate (car [rndCar], carPointLTR.position, carPointLTR.rotation);
					spawnCounter = carSpawnDelay;
				}

			}
		}
		
	}

	int GetRandomCar(){

		return Random.Range (0, car.Length);

	}
}
