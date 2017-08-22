using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsAnimation : MonoBehaviour {

	public GameObject coinEndPoint;
	public GameObject coinStartPoint;
	public float coinAnimDuration = 1.0f;
	private Vector3 scaleTo = new Vector3 (0.1f, 0.1f, 0.1f);

	// Use this for initialization
	void Start () {
		//this.gameObject.transform.position = coinStartPoint.transform.position;


	}
	public void StartAimation(){
		iTween.MoveTo (this.gameObject,iTween.Hash("position", coinEndPoint.transform.position,"scale",scaleTo,"time" , coinAnimDuration,"oncomplete", "HideMe"));
	}
	void HideMe(){
		var renderer = GetComponent<Renderer> ();
		renderer.enabled = false;

	}



}
