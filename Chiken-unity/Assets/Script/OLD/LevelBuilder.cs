using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {


	//List<GameObject> prefabList = new List<GameObject> ();
	public GameObject[] RoadsGO;
	// 0 - Grass
	// 1 - Bicycle
	// 2 - Reg Car
	// 3 - Police
	// 4 - Train
	// 5 - Limuzine
	// 6 - Airplane
	// levelArr1 = [0,1,2,2,2,2,2];
	// levelArr2 = [0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3];
	// levelArr3 = [0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,4];
	// levelArr4 = [0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,4,5];
	// levelArr5 = [0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,4,5,6];


	private Transform RoadsLoc;



	public float roadNum;
	private float rndDir;
	private float newY;
	private int roadID;


	// Use this for initialization
	void Start () {
		//build roads for Level

		for (int i = 0; i < roadNum; i++) {
			newY =-400 +(i * 54);
			transform.position = new Vector3(0f,newY,0f);
			switch (i) {
			case 5:
				roadID = 0;
				break;
			case 6:
				roadID = 1;
				break;
			default:
				roadID = 2;
				if (returnRndDir())
					RoadsGO [roadID].GetComponent<carCreator> ().RTL = true;
				else
					RoadsGO [roadID].GetComponent<carCreator> ().RTL = false;
				
				break;
				
			}

			RoadsGO [roadID].gameObject.tag = "Road";
			Instantiate (RoadsGO [roadID],transform.position,transform.rotation);

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool returnRndDir(){
		rndDir = Random.Range (0, 10);
	//	Debug.Log (rndDir);
		if (rndDir < 5) {
			return true;
		}else{
			return false;
		}
	}
}
