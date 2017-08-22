using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour {

	public AudioClip gameBGSound;

	public int currentPlayerScore = 0;
	private int topScore;
	private int roundScore;
	public Text scoreTxt;
	public TextMeshPro scoreTxtPro;
	private bool pauseOn = false;
	private bool newTopScore = false;
	//public GameObject player;
	public GameObject nightSprite;
	public Vector2 startEndNightAt = new Vector2(100,150);
	public float timeToDark = 20.0f; 
	public bool presentCollect = false;
	private UserXP userXP;



	// Use this for initialization
	void Start () {
		roundScore = 0;
		currentPlayerScore = 0;
		topScore = PlayerPrefs.GetInt ("topScore");
		PlayerPrefs.SetInt("present",1); // 1 = no present collected. 
		print ("Have present (0 - yes, 1 - no)= " + PlayerPrefs.GetInt("present"));
		iTween.FadeTo (nightSprite, 0f, 0f);
		if(gameBGSound)
			AudioSource.PlayClipAtPoint (gameBGSound, transform.position,1f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetPlayerScore(){

		currentPlayerScore += 1;
	//	print("currentPlayerScore = " + currentPlayerScore);
		scoreTxtPro.text = currentPlayerScore.ToString ();
		roundScore++;
		if (currentPlayerScore == startEndNightAt.x) {
			StartNightMode ();
		}
		if (currentPlayerScore == startEndNightAt.y) {
			EndNightMode ();
		}
	}
	public void StartNightMode(){
		iTween.FadeTo (nightSprite, 1f, timeToDark);
	}
	public void EndNightMode(){
		iTween.FadeTo (nightSprite, 0f, timeToDark);
	}
	public void CheckBestScore(){
		
		PlayerPrefs.SetInt("roundScore",roundScore);
		if (currentPlayerScore > topScore) {
			topScore = currentPlayerScore;
			newTopScore = true;
		}
		print ("topScore = " + topScore);

		PlayerPrefs.SetInt("topScore",topScore);
		if (newTopScore) {
			StartCoroutine(LoadLevel("HighScore", 1f));
		} else {
			StartCoroutine(LoadLevel("EndGame", 1f));
		}

	}

	IEnumerator LoadLevel( string _name, float _delay) {
		yield return new WaitForSeconds(_delay);
		Application.LoadLevel(_name);
		print ("endlevel");
	}

	public void PauseTaggle(){
		if (pauseOn) {
			ResumeGame ();
			pauseOn = false;
		} else {
			PauseGame ();
			pauseOn = true;
		}

	}
	/*
	public void ActivePlayerShield(){
		if (player.GetComponent<CarHit> ().shieldActive == false) {
			player.GetComponent<CarHit> ().ShiledOn ();
		}

	}
*/
	void PauseGame(){
		Time.timeScale = 0;
	}

	void ResumeGame(){
		Time.timeScale = 1;
	}
}
