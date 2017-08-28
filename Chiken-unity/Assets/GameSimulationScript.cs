using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSimulationScript : MonoBehaviour {

	public GameObject mainGO;
	public GameObject playerGO;
	private GameManagerScript gameManager;
	private CarHit carHit;
	private PlayerMoveiTween playerMove;
	public Vector2 randomScore;

	// Use this for initialization
	void Start () {
		playerMove = mainGO.GetComponent<GameManagerScript> ();
		carHit = playerGO.GetComponent<CarHit> ();
		playerMove = playerGO.GetComponent<PlayerMoveiTween> ();
	}
	
	// Update is called once per frame
	void SimulateGame () {
		//randmo score
		var rndScore = Random.Range(randomScore.x,randomScore.y); 
		gameManager = rndScore;
		roundScore = rndScore;
	}
}
