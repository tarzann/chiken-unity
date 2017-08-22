using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecyle{

	void Restart();
	void Shutdown();
	void Start ();
}


public class RecycleGameObject : MonoBehaviour {

	private List<IRecyle> recycleComponents;

	void Awake(){
		var components = GetComponents<MonoBehaviour> ();
		recycleComponents = new List<IRecyle> ();
		foreach (var component in components) {

			if (component is IRecyle) {

				recycleComponents.Add (component as IRecyle);

			}
		}


	}


	// Use this for initialization
	public void Restart () {
		gameObject.SetActive(true);

		foreach (var component in recycleComponents) {

			component.Restart ();
		}

	}
	
	// Update is called once per frame
	public void Shutdown () {
		gameObject.SetActive (false);

		foreach (var component in recycleComponents) {

			component.Shutdown ();
		}
	}
}
