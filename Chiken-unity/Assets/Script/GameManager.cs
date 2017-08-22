using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private int currentPlayerScore = 0;
	private int topScore;


	// Use this for initialization
	void Start () {
		currentPlayerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setPlayerScore(){

		currentPlayerScore += 1;
		print("currentPlayerScore = " + currentPlayerScore);

	}
}
