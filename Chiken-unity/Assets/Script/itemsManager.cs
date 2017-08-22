using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsManager : MonoBehaviour {

	public GameObject[] items;
	//private int[] inArr = new int[0];

	// Use this for initialization
	void Start () {
		
		//PlayerPrefsX.SetIntArray ("userItems", inArr);

		var userItemsArray = PlayerPrefsX.GetIntArray("userItems");
		foreach(int n in userItemsArray){
			var x = n - 10;
			print (items [x].name);
			var renderer = items[x].GetComponent<SpriteRenderer> ();
			renderer.sprite = items[x].GetComponent<GiftItems> ().sprites[x+10];


		}

	}
	public void PlayAgain(){
		Application.LoadLevel("Game");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
