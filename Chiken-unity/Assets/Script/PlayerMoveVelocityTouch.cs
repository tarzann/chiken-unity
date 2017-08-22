using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveVelocityTouch : MonoBehaviour {


	private AudioSource audioSource;
	public AudioClip moveClip;

	public Transform roadDestroyer;
	public Transform nextPosition;
	public float speed = 160f;
	private Vector3 desiredVelocity;
	private float lastSqrMag;
	private Rigidbody2D rigidbody;
	public bool actionButton;
	public bool moveOn;
	private float sqrMag;

	public GameObject roadsObj;
	private SpwnRoad spwnRoad;

	public GameObject gameManagerObj;
	private GameManagerScript gameManager;
	private Animator animator;

	private Vector2 touchOrigin = -Vector2.one;


	public float closeDistance = 5.0F;


	void Start(){
		rigidbody = GetComponent<Rigidbody2D> ();
		//gameManagerObj = GameObject.Find ("GameManger");
		gameManager = gameManagerObj.GetComponent<GameManagerScript> ();
		spwnRoad = roadsObj.GetComponent<SpwnRoad> ();
		animator = GetComponent<Animator> ();
		Vector3 directionalVector = (nextPosition.position - transform.position).normalized * speed;

		// reset lastSqrMag
		lastSqrMag = Mathf.Infinity;

		// apply to rigidbody velocity
		desiredVelocity = directionalVector;
	}

	void Update() {
		actionButton = Input.anyKeyDown;

		if (nextPosition) {
			Vector3 offset = nextPosition.position - transform.position;
			float sqrLen = offset.sqrMagnitude;
			if (sqrLen < closeDistance * closeDistance) {
				//print ("The other transform is close to me!");
				desiredVelocity = Vector3.zero;
			}

		}
		if (Input.touchCount > 0) {

			Touch myTouch = Input.touches [0];
			if (myTouch.phase == TouchPhase.Began) {
				PlayMoveSound ();
				nextPosition.position = new Vector3 (nextPosition.position.x, nextPosition.position.y + 53.3f, nextPosition.position.z);
				roadDestroyer.position = new Vector3 (0, roadDestroyer.position.y + 53.3f, 0);
				Vector3 directionalVector = (nextPosition.position - transform.position).normalized * speed;
				lastSqrMag = Mathf.Infinity;
				desiredVelocity = directionalVector;
				gameManager.SetPlayerScore ();
				//print (spwnRoad);
				if (spwnRoad)
					spwnRoad.AddRoad ();
			}
		}
			
	}

	void PlayMoveSound(){
		animator.SetInteger ("AnimationStat", 1);
		audioSource.clip = moveClip;
		audioSource.Play ();
	}


	void FixedUpdate() {
		//if(moveOn)
		animator.SetInteger ("AnimationStat", 0);
		rigidbody.velocity = desiredVelocity;

	}
}
