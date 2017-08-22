using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndRoundManagar : MonoBehaviour {


	private int topScore;
	private int roundScore;
	private int userCoins;
	public TextMeshPro scoreTxt;
	public TextMeshPro bestTxt;
	public TextMeshPro coinsTxt;
	public GameObject present;
	public GameObject gift;
	private int havePresent = 1;
	private RandomItem rndItem;

	public int itemCategoriesCount = 1;
	public int itemsInCategory = 5;
	private int randomItem = 0;
	private int randomCoins = 0;
	private int newItemID;

	public GameObject coinPrefab;
	public GameObject coinStartPoint;
	public int coinsNumber;
	public float delay;
	public bool active = true;
	private int coinsApplied = 0;


	// Use this for initialization
	void Start () {
		userCoins = PlayerPrefs.GetInt ("userCoins");
		topScore = PlayerPrefs.GetInt ("topScore");
		roundScore = PlayerPrefs.GetInt ("roundScore");
		havePresent = PlayerPrefs.GetInt ("present");
		coinsTxt.text = userCoins.ToString ();
		scoreTxt.text = roundScore.ToString ();
		bestTxt.text = topScore.ToString ();
		present.SetActive(false);
		print ("have present = " + havePresent);
		if (havePresent == 0) {
			present.SetActive(true);
			GetRandomPresent ();
		} else {
			present.SetActive(false);
		}
		StartCoroutine (AddCoin ());

	}


	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator AddCoin(){
		coinsApplied++;
		yield return new WaitForSeconds (delay);

		var newTransform = transform;
		var clone = Instantiate (coinPrefab, coinStartPoint.transform.position,coinStartPoint.transform.rotation);

		float rndX = Random.Range (0.0f, 4.0f);
		rndX -= 2.0f;
		float rndY = Random.Range (0.0f, 4.0f);
		rndY -= 2.0f;

		coinStartPoint.transform.position = new Vector3 (coinStartPoint.transform.position.x + rndX, coinStartPoint.transform.position.y + rndY, coinStartPoint.transform.position.z);
		clone.transform.position = coinStartPoint.transform.position;
		clone.name = "coin" + coinsApplied;
		if (coinsApplied < coinsNumber)
			StartCoroutine (AddCoin ());
		else {

			for (var i = 1; i < coinsApplied+1;i++) {
				//StartCoroutine (ActiveCoinAnimation (i));
				GameObject.Find ("coin" + i).GetComponent<CoinsAnimation> ().StartAimation ();
				userCoins++;
				coinsTxt.text = userCoins.ToString ();
				yield return new WaitForSeconds (0.07f);

			}
		}
	}

	public void PlayAgain(){
		Application.LoadLevel("Game");
	}
	IEnumerator StartNewGame(float _delay){
		yield return new WaitForSeconds(_delay);
		Application.LoadLevel("Game");
	}
	public void GoToInventory(){
		Application.LoadLevel("Inventory");
	}
	public void GetRandomPresent(){
		int rndPackage = Random.Range (0, itemCategoriesCount);
		int rnd = Random.Range (0, 100);
		if (rnd == 99) {
			randomItem = 5;
		} else if (rnd < 99 && rnd > 94) {
			randomItem = 4;
		} else if (rnd < 95 && rnd > 79) {
			randomItem = 3;
		} else if (rnd < 80 && rnd > 49) {
			randomItem = 2;
		} else {
			randomItem = 1;
		}
		newItemID = (((rndPackage * 5) + 1) + (randomItem - 1)+10);
		print ("newItemID = " + newItemID);
		UpdatePlayerItemsArray ();


	}
	void UpdatePlayerItemsArray(){
		//get current items array;
		bool exsistInArray = false;
		var userItemsArray = PlayerPrefsX.GetIntArray("userItems");
		//check if item exsist
		foreach(int n in userItemsArray){
			print ("n = " + n);
			if (n == newItemID) {
				exsistInArray = true;
				print ("item already exsist");
			}
		}
		//update if not in inventory
		if (exsistInArray == false) {
			//reset the array with new item
			int[] newIntArr = new int[userItemsArray.Length + 1];
			userItemsArray.CopyTo (newIntArr, 0);
			newIntArr [newIntArr.Length - 1] = newItemID;
			//save to memory
			PlayerPrefsX.SetIntArray ("userItems", newIntArr);
			PlayerPrefs.SetInt("newItemToShow",newItemID);
			print ("new item added to items array");
			DisplayGiftImgInPresent ();
		} else {
			//item already exsist - give coins instead
			GetRandomCoinsPack();
			DisplayGiftImgInPresent ();
		}

	}
	void GetRandomCoinsPack(){
		int rnd = Random.Range (0, 100);
		if (rnd == 99) {
			randomCoins = 1;
		} else if (rnd < 99 && rnd > 90) {
			randomCoins = 2;
		} else if (rnd < 95 && rnd > 79) {
			randomCoins = 1;
		} else if (rnd < 80 && rnd > 49) {
			randomCoins = 2;
		} else {
			randomCoins = 1;
		}

		PlayerPrefs.SetInt("newItemToShow",randomCoins);
		print ("item exsist recive coins = " + randomCoins);
	}
	void DisplayGiftImgInPresent(){
		int getGiftID = PlayerPrefs.GetInt("newItemToShow");
		var renderer = gift.GetComponent<SpriteRenderer> ();
		renderer.sprite = gift.GetComponent<GiftItems>().sprites[getGiftID];

	}
}
