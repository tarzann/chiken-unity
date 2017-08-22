using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwnCar : MonoBehaviour {

	public GameObject[] prefabs;
	public float delay = 2f;
	public bool active = true;
	public Vector2 delayRange = new Vector2 (1, 2);


	// Use this for initialization
	void Start () {
		ResetDelay ();
		StartCoroutine (CarGenerator ());

	}

	IEnumerator CarGenerator(){
		yield return new WaitForSeconds (delay);

		if (active) {

			var newTransform = transform;
			//var clone = GameObjectUtil.Instantiate (prefabs [Random.Range (0, prefabs.Length)], newTransfor.position);
			var clone = Instantiate (prefabs [Random.Range (0, prefabs.Length)], newTransform.position,newTransform.rotation);
			clone.transform.position = transform.position;
			//clone.transform.position = new Vector3(0,0+(cloneSize.y*i),0);
			clone.transform.parent = transform;
			clone.tag = "Car";
			ResetDelay (); 
		}

		StartCoroutine (CarGenerator ());
	}
	
	void ResetDelay(){
		delay = Random.Range (delayRange.x, delayRange.y);
	}
}
