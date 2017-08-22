using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeLevel : MonoBehaviour {

	void Update(){
		if (this.name == "Game") {
			print ("HOLA");
		}
	}

	public void LoadGameScene(){
		Application.LoadLevel ("Game");
	}

	public void SetLevel(int destination){
		print (destination);
		Application.LoadLevel (destination);
	}
}
