using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclesEmergency : MonoBehaviour {

	public GameObject[] prefabs;
	public Vector2 colliderOffset = Vector2.zero;


	// Use this for initialization
	void Start () {
		var rnd = Random.Range (0, prefabs.Length);
		var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);




		//var collider = GetComponent<BoxCollider2D> ();


		clone.transform.position = transform.position;
		//var renderer = clone.GetComponent<SpriteRenderer> ();
		//var cloneSize = renderer.bounds.size;
		//clone.transform.position = new Vector3 (0,  - (cloneSize.y * (k+1)), 0);
		//clone.transform.parent = transform;
		clone.tag = "Car";			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
