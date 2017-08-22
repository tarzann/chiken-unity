using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour,IRecyle {

	public Sprite[] sprites;

	public Vector2 colliderOffset = Vector2.zero;



	public void Restart(){
		
		//print ("sprites.Length = " + sprites.Length);
		var renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = sprites[Random.Range(0,sprites.Length)];

		var collider = GetComponent<BoxCollider2D> ();
		var size = renderer.bounds.size;
		size.y += colliderOffset.y;
		collider.size = size;
		collider.offset = new Vector2 (-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);


	}

	public void Start(){
		//print ("sprites.Length = " + sprites.Length);
		var renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = sprites[Random.Range(0,sprites.Length)];


		var collider = GetComponent<BoxCollider2D> ();
		var size = renderer.bounds.size;
		size.y += colliderOffset.y;
		collider.size = size;
		collider.offset = new Vector2 (-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);


	}


	public void Shutdown(){


	}


}
