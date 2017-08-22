using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeGameManager : MonoBehaviour {

	public bool actionButton = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		actionButton = false;
		actionButton = Input.anyKeyDown;
		if (actionButton) {   //keyboard
			print("aa");
			Application.LoadLevel ("Game");
		}
	}
}
