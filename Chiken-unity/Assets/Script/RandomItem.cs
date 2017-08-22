using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour {

	public int itemCategoriesCount;
	public int itemsInCategory = 5;

	private int randomItem = 0;
	private int p1 = 0;
	private int p2 = 0;
	private int p3 = 0;
	private int p4 = 0;
	private int p5 = 0;

	private int[] itemsFrequancy = new int[]{50,30,15,4,1}; //out of 100
	private string[] itemsCategoriesName = new string[]{"cookie","tool"}; //out of 100

	// Use this for initialization
	void Start () {
		//GetRandomPresent ();
	}
	
	// Update is called once per frame
	public void GetRandomPresent(){
		int rndPackage = Random.Range (0, itemCategoriesCount);
		int rnd = Random.Range (0, 100);
		if (rnd == 99) {
			p5++;
			randomItem = 5;
		} else if (rnd < 99 && rnd > 94) {
			p4++;
			randomItem = 4;
		} else if (rnd < 95 && rnd > 79) {
			p3++;
			randomItem = 3;
		} else if (rnd < 80 && rnd > 49) {
			p2++;
			randomItem = 2;
		} else {
			p1++;
			randomItem = 1;
		}
		print ("getRandomPersent");
		int itemLocInArray = ((rndPackage * 5) + 1) + (randomItem - 1);
		PlayerPrefs.SetInt("presentRnd",itemLocInArray);
		print ("presentRnd = "+itemLocInArray);
	}

	void TestRandom(){
		for (int i = 0; i < 100; i++) {
			GetRandomPresent ();
		}
		print ("p1 = " + p1);
		print ("p2 = " + p2);
		print ("p3 = " + p3);
		print ("p4 = " + p4);
		print ("p5 = " + p5);
	}
}
