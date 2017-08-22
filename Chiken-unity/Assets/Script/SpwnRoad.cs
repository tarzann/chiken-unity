using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnRoad : MonoBehaviour {

	public GameObject[] prefabs;
	public float delay = 0.1f;
	public bool active = true;
	public int numberOfInitRoads = 20;
	private int roadsCount = 0;
	private int currentLevel = 1;
	private int roadsDeployInLevel = 0;
	private int belowPlayerPosRoads = 10;
	private float roadHeight = 53.3f;
	//public Vector2 delayRange = new Vector2 (1, 2);

	// 0 - Grass
	// 1 - Bicycle
	// 2 - Reg Car random to RTL or LTR
	// 3 - Reg Car LTR
	// 4 - Police
	// 5 - Train
	// 6 - Airplane
	// 7 - Limuzine

	//99 - random

	private int levelArrNum = 9;
	private int[] levelArr1 = {0,1,2,2,2,2,2,2};//8
	private int[] levelArr2 = {0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,4};//18
	private int[] levelArr3 = {0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,4,4,5};//28
	private int[] levelArr4 = {0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,4,4,5,6};//36
	private int[] levelArr5 = {0,1,2,2,2,2,2,2,2,2,2,2,4,2,2,2,2,2,2,2,2,2,2,5,2,2,2,2,2,2,2,2,2,2,2,2,2,4,4,4,5,6,2};//43
	private int[] levelArr6 = {0,1,2,2,2,2,2,5,2,2,2,2,2,2,2,2,2,2,2,4,2,2,2,2,2,5,2,2,2,2,2,2,2,2,2,2,2,4,4,4,5,6,2};//43
	private int[] levelArr7 = {0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,4};//18
	private int[] levelArr8 = {0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,4};//18
	private int[] levelArr9 = {0,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99};//58

	private int rnd;

	// Use this for initialization
	void Start () {
		//ResetDelay ();
		RoadGenerator ();
	}

	void RoadGenerator(){
		

		for (var k = 0; k < belowPlayerPosRoads; k++) {
			rnd = Random.Range (0, 10);
			if (rnd <= 5)
				rnd = 2;
			else
				rnd = 3;
//			print ("rnd = " + rnd);

			var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			clone.transform.position = transform.position;
			var renderer = clone.GetComponent<SpriteRenderer> ();
			var cloneSize = renderer.bounds.size;
			clone.transform.position = new Vector3 (0,  - (roadHeight * (k+1)), 0);
			clone.transform.parent = transform;
			clone.tag = "Road";
			//roadsCount++;
		}

		for (var i = 0; i < numberOfInitRoads; i++) {
			rnd = Random.Range (0, 10);
			if (rnd <= 5)
				rnd = 2;
			else
				rnd = 3;
			
			var roadType = 0;

			if (i == 0) {	
				roadType = 0;
			} else {
				roadType = rnd;
			}
			if (i % 5 == 0)
				roadType = 0;
				
//			print ("rnd = " + rnd);
			var clone = Instantiate (prefabs [roadType], new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			clone.transform.position = transform.position;
			var renderer = clone.GetComponent<SpriteRenderer> ();
			var cloneSize = renderer.bounds.size;
			clone.transform.position = new Vector3 (0, 0 + (roadHeight * i), 0);
			clone.transform.parent = transform;
			clone.tag = "Road";
			roadsCount++;
		}
	
	}
	int ReturnRoad(int roadType){
		int rnd;
		if (roadType == 99) {
			rnd = Random.Range (1, 7);
			return rnd;
		} else {
			if (roadType == 2) {
				rnd = Random.Range (0, 10);
				if (rnd <= 5)
					return  2;
				else
					return 3;
			} else {
				return roadType;
			}
		}

	}

	public void AddRoad(){


		switch (currentLevel) {
		case 1:	
			if (roadsDeployInLevel < levelArr1.Length) {
				rnd = ReturnRoad (levelArr1[roadsDeployInLevel]);
				var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z),transform.rotation);
				clone.transform.position = transform.position;
				var renderer = clone.GetComponent<SpriteRenderer> ();
				var cloneSize = renderer.bounds.size;
				clone.transform.position = new Vector3 (0, 0 + (roadHeight * roadsCount), 0);
				clone.transform.parent = transform;
				if(rnd == 4)
					clone.tag = "PoliceRoad";
				else
					clone.tag = "Road";
				roadsCount++;
				roadsDeployInLevel++;

			} else {
				currentLevel++;
				roadsDeployInLevel = 0;

			}
			break;
		case 2:	
			if (roadsDeployInLevel < levelArr2.Length) {
				rnd = ReturnRoad (levelArr2[roadsDeployInLevel]);
				var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
				clone.transform.position = transform.position;
				var renderer = clone.GetComponent<SpriteRenderer> ();
				var cloneSize = renderer.bounds.size;
				clone.transform.position = new Vector3 (0, 0 + (roadHeight * roadsCount), 0);
				clone.transform.parent = transform;
				if(rnd == 4)
					clone.tag = "PoliceRoad";
				else
					clone.tag = "Road";
				
				roadsCount++;
				roadsDeployInLevel++;
		
			} else {
				currentLevel++;
				roadsDeployInLevel = 0;

			}
			break;
		case 3:	
			if (roadsDeployInLevel < levelArr3.Length) {
				rnd = ReturnRoad (levelArr3[roadsDeployInLevel]);
				//print ("roadsDeployInLevel = " + rnd);
				//var clone = GameObjectUtil.Instantiate (prefabs [levelArr1 [roadsDeployInLevel]], new Vector3 (transform.position.x, transform.position.y, transform.position.z));
				var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z),transform.rotation);
				clone.transform.position = transform.position;
				var renderer = clone.GetComponent<SpriteRenderer> ();
				var cloneSize = renderer.bounds.size;
				clone.transform.position = new Vector3 (0, 0 + (roadHeight * roadsCount), 0);
				clone.transform.parent = transform;
				if(rnd == 4)
					clone.tag = "PoliceRoad";
				else
					clone.tag = "Road";
				roadsCount++;
				roadsDeployInLevel++;
			} else {
				currentLevel++;
				roadsDeployInLevel = 0;

			}
			break;
		case 4:	
			if (roadsDeployInLevel < levelArr4.Length) {
				rnd = ReturnRoad (levelArr4[roadsDeployInLevel]);
				//print ("roadsDeployInLevel = " + roadsDeployInLevel);
				//var clone = GameObjectUtil.Instantiate (prefabs [levelArr1 [roadsDeployInLevel]], new Vector3 (transform.position.x, transform.position.y, transform.position.z));
				var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z),transform.rotation);
				clone.transform.position = transform.position;
				var renderer = clone.GetComponent<SpriteRenderer> ();
				var cloneSize = renderer.bounds.size;
				if (rnd == 6) //airplane
					roadsCount++;
				clone.transform.position = new Vector3 (0, 0 + (roadHeight * roadsCount), 0);
				clone.transform.parent = transform;
				if(rnd == 4)
					clone.tag = "PoliceRoad";
				else
					clone.tag = "Road";
				if (rnd == 6) //airplane
					roadsCount++;
				
				roadsCount++;
				roadsDeployInLevel++;
			} else {
				currentLevel++;
				roadsDeployInLevel = 0;

			}
			break;
		case 5:	
			print ("roadsDeployInLevel 5 = " + roadsDeployInLevel);
			if (roadsDeployInLevel < levelArr5.Length) {
				rnd = ReturnRoad (levelArr5[roadsDeployInLevel]);
				//print ("roadsDeployInLevel = " + roadsDeployInLevel);
				//var clone = GameObjectUtil.Instantiate (prefabs [levelArr1 [roadsDeployInLevel]], new Vector3 (transform.position.x, transform.position.y, transform.position.z));
				var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
				clone.transform.position = transform.position;
				var renderer = clone.GetComponent<SpriteRenderer> ();
				var cloneSize = renderer.bounds.size;
				if (rnd == 6) //airplane
					roadsCount++;
				clone.transform.position = new Vector3 (0, 0 + (roadHeight * roadsCount), 0);
				clone.transform.parent = transform;
				if(rnd == 4)
					clone.tag = "PoliceRoad";
				else
					clone.tag = "Road";
				if (rnd == 6) //airplane
					roadsCount++;
				
				roadsCount++;
				roadsDeployInLevel++;
			} else {
				
				currentLevel++;
				roadsDeployInLevel = 0;

			}
			break;
		case 6:	
			print ("roadsDeployInLevel 6 = " + roadsDeployInLevel);
			if (roadsDeployInLevel < levelArr6.Length) {
				rnd = ReturnRoad (levelArr6[roadsDeployInLevel]);
				//print ("roadsDeployInLevel = " + roadsDeployInLevel);
				//var clone = GameObjectUtil.Instantiate (prefabs [levelArr1 [roadsDeployInLevel]], new Vector3 (transform.position.x, transform.position.y, transform.position.z));
				var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
				clone.transform.position = transform.position;
				var renderer = clone.GetComponent<SpriteRenderer> ();
				var cloneSize = renderer.bounds.size;
				if (rnd == 6) //airplane
					roadsCount++;
				clone.transform.position = new Vector3 (0, 0 + (roadHeight * roadsCount), 0);
				clone.transform.parent = transform;
				if(rnd == 4)
					clone.tag = "PoliceRoad";
				else
					clone.tag = "Road";
				if (rnd == 6) //airplane
					roadsCount++;

				roadsCount++;
				roadsDeployInLevel++;
			} else {

				currentLevel++;
				roadsDeployInLevel = 0;

			}
			break;
		case 7:	
			print ("roadsDeployInLevel 7 = " + roadsDeployInLevel);
			if (roadsDeployInLevel < levelArr7.Length) {
				rnd = ReturnRoad (levelArr7[roadsDeployInLevel]);
				//print ("roadsDeployInLevel = " + roadsDeployInLevel);
				//var clone = GameObjectUtil.Instantiate (prefabs [levelArr1 [roadsDeployInLevel]], new Vector3 (transform.position.x, transform.position.y, transform.position.z));
				var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
				clone.transform.position = transform.position;
				var renderer = clone.GetComponent<SpriteRenderer> ();
				var cloneSize = renderer.bounds.size;
				if (rnd == 6) //airplane
					roadsCount++;
				clone.transform.position = new Vector3 (0, 0 + (roadHeight * roadsCount), 0);
				clone.transform.parent = transform;
				if(rnd == 4)
					clone.tag = "PoliceRoad";
				else
					clone.tag = "Road";
				if (rnd == 6) //airplane
					roadsCount++;

				roadsCount++;
				roadsDeployInLevel++;
			} else {

				currentLevel++;
				roadsDeployInLevel = 0;

			}
			break;
		case 8:	
			print ("roadsDeployInLevel 8 = " + roadsDeployInLevel);
			if (roadsDeployInLevel < levelArr8.Length) {
				rnd = ReturnRoad (levelArr8[roadsDeployInLevel]);
				//print ("roadsDeployInLevel = " + roadsDeployInLevel);
				//var clone = GameObjectUtil.Instantiate (prefabs [levelArr1 [roadsDeployInLevel]], new Vector3 (transform.position.x, transform.position.y, transform.position.z));
				var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
				clone.transform.position = transform.position;
				var renderer = clone.GetComponent<SpriteRenderer> ();
				var cloneSize = renderer.bounds.size;
				if (rnd == 6) //airplane
					roadsCount++;
				clone.transform.position = new Vector3 (0, 0 + (roadHeight * roadsCount), 0);
				clone.transform.parent = transform;
				if(rnd == 4)
					clone.tag = "PoliceRoad";
				else
					clone.tag = "Road";
				if (rnd == 6) //airplane
					roadsCount++;

				roadsCount++;
				roadsDeployInLevel++;
			} else {

				currentLevel++;
				roadsDeployInLevel = 0;

			}
			break;
		case 9:	
			print ("roadsDeployInLevel 9 = " + roadsDeployInLevel);
			if (roadsDeployInLevel < levelArr9.Length) {
				rnd = ReturnRoad (levelArr9[roadsDeployInLevel]);
				//print ("roadsDeployInLevel = " + roadsDeployInLevel);
				//var clone = GameObjectUtil.Instantiate (prefabs [levelArr1 [roadsDeployInLevel]], new Vector3 (transform.position.x, transform.position.y, transform.position.z));
				var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
				clone.transform.position = transform.position;
				var renderer = clone.GetComponent<SpriteRenderer> ();
				var cloneSize = renderer.bounds.size;
				if (rnd == 6) //airplane
					roadsCount++;
				clone.transform.position = new Vector3 (0, 0 + (roadHeight * roadsCount), 0);
				clone.transform.parent = transform;
				if(rnd == 4)
					clone.tag = "PoliceRoad";
				else
					clone.tag = "Road";

				if (rnd == 6) //airplane
					roadsCount++;

				roadsCount++;
				roadsDeployInLevel++;
			} else {
				print ("set level again to 9");
				currentLevel=9;
				roadsDeployInLevel = 0;

			}
			break;
		default:
			if (roadsDeployInLevel < levelArr5.Length) {
				rnd = ReturnRoad (levelArr6[roadsDeployInLevel]);
				//print ("roadsDeployInLevel = " + roadsDeployInLevel);
				//var clone = GameObjectUtil.Instantiate (prefabs [levelArr1 [roadsDeployInLevel]], new Vector3 (transform.position.x, transform.position.y, transform.position.z));
				var clone = Instantiate (prefabs [rnd], new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
				clone.transform.position = transform.position;
				var renderer = clone.GetComponent<SpriteRenderer> ();
				var cloneSize = renderer.bounds.size;
				if (rnd == 6) //airplane
					roadsCount++;
				
				clone.transform.position = new Vector3 (0, 0 + (roadHeight * roadsCount), 0);
				clone.transform.parent = transform;
				if(rnd == 4)
					clone.tag = "PoliceRoad";
				else
					clone.tag = "Road";
				
				if (rnd == 6) //airplane
					roadsCount++;

				roadsCount++;
				roadsDeployInLevel++;
			} else {
				currentLevel++;
				if (currentLevel >= 6)
					currentLevel = 6;
				
				roadsDeployInLevel = 0;

			}
			break;


		}


		if (roadsCount % 5 == 0) {
//			print ("roadsCount % 5 = " + roadsCount % 5);
			AddRoad ();
		}




		//print ("Road has been added");
		//clone = GameObjectUtil.RemoveObjectPool (prefabs [0]);

	}

	void RndNoRepeat(){
		/*
		var random = new Random ();
		var numbers = Enumerable.Range (1, 49).TakeRandom (6, random);
		numbers.Shuffle (random);

		HashSet<int> numbers = new HashSet<int>();
		while (numbers.Count < 6) {
			numbers.Add(random.Next(1, 49));
		}*/
	}

}
