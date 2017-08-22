using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreSecne : MonoBehaviour {

	private int topScore;
	public Text bestTxt;


	// Use this for initialization
	void Start () {
		topScore = PlayerPrefs.GetInt ("topScore");

		bestTxt.text = topScore.ToString ();
		//StartCoroutine ("StartNewGame", 3f);
	}


	// Update is called once per frame
	void Update () {

	}
	public void PlayAgain(){
		Application.LoadLevel("Game");
	}
	IEnumerator StartNewGame(float _delay){
		yield return new WaitForSeconds(_delay);
		Application.LoadLevel("Game");
	}
}
