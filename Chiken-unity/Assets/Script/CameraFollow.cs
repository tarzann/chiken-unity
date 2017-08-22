using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	private Transform _t;


	// Use this for initialization
	void Start () {
		if (target != null) {
			_t = target.transform;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = new Vector3 (_t.position.x, _t.position.y, transform.position.z);
		}
	}
}
