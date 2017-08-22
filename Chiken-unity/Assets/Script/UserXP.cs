using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserXP : MonoBehaviour {

	private int userLevel;
	private int userXP;
	private int timePlayed;
	private int userAverageScore;
	private int userTotalScore;
	private int topScore;
	public Text userLevelTxt;
	public Text userXPTxt;
	public Text timePlayedTxt;
	private int[] levelRoadPast = new int[]{0,26,82,176,204}; // road past
	private int[] levelTimePlayed = new int[]{0,100,300,1000,2500}; // time played


	// Use this for initialization
	void Start () {
		GetXP ();
		userLevelTxt.text = "user leve: " + userLevel;
		userXPTxt.text = "user XP: " + userXP;
		timePlayedTxt.text = "time played: " + timePlayed;
		PrinteXP ();
	}
	void GetXP(){
		userLevel = PlayerPrefs.GetInt ("userLevel");
		userXP = PlayerPrefs.GetInt ("userXP");
		timePlayed = PlayerPrefs.GetInt ("timePlayed");
		userAverageScore = PlayerPrefs.GetInt ("userAverageScore");
		topScore = PlayerPrefs.GetInt ("topScore");
	}
	void PrinteXP(){
		print ("userLevel = " + userLevel);
		print ("userXP = " + userXP);
		print ("timePlayed = " + timePlayed);
		print ("userAverageScore = " + userAverageScore);
		print ("topScore = " + topScore);
	}
	void SaveXP(){
		PlayerPrefs.SetInt ("userLevel",userLevel);
		PlayerPrefs.SetInt ("userXP",userXP);
		PlayerPrefs.SetInt ("timePlayed",timePlayed);
		PlayerPrefs.SetInt ("userAverageScore",userAverageScore);
	}
		

	// Update is called once per frame
	public void UpdateXP (int _roundScore) {
		timePlayed++;
		userXP += _roundScore;
		SetUserLevel ();
		SetUserAverageScore ();
		SaveXP ();
	}
	void SetUserAverageScore (){

		userAverageScore = userXP / timePlayed;

	}
	void SetUserLevel(){
		var userLvlx = 0;
		var userLvly = 0;
		for (var i = 0; i < 5; i++) {
			if (levelRoadPast[i] < topScore) {
				userLvlx = i + 1;
				//print ("userLvlx = " + userLvlx);
			}
		}
		for (var k = 0; k < 5; k++) {
			if (levelTimePlayed[k] < timePlayed) {
				userLvly = k + 1;
				//print ("userLvly = " + userLvly);
			}
		}
		if (userLvlx < userLvly) {
			userLevel = userLvlx;
		} else if (userLvlx > userLvly) {
			userLevel = userLvly;
		} else {
			userLevel = userLvlx;
		}

	}
}
