using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMoveVelocity : MonoBehaviour {


	private AudioSource audioSource;
	public AudioClip moveClip;

	public Transform roadDestroyer;
	public Transform nextPosition;
	public Transform roadAlert;
	public float speed = 170f;
	private Vector3 desiredVelocity;
	private float lastSqrMag;
	private Rigidbody2D rigidbody;
	public bool actionButton = false;
	public bool moveOn;
	private float sqrMag;

	public GameObject roadsObj;
	private SpwnRoad spwnRoad;

	public GameObject gameManagerObj;
	private GameManagerScript gameManager;
	private Animator animator;
	public ParticleSystem stepSmoke;
	Camera camera;

	public float closeDistance = 2.0F;


	void Awake(){

		//nextPosition.position = new Vector3 (nextPosition.position.x, nextPosition.position.y + 53.3f, nextPosition.position.z);

	}
	void Start(){
		stepSmoke.enableEmission = false;
		rigidbody = GetComponent<Rigidbody2D> ();
		gameManager = gameManagerObj.GetComponent<GameManagerScript> ();
		spwnRoad = roadsObj.GetComponent<SpwnRoad> ();
		audioSource = GetComponent<AudioSource> ();
		animator = GetComponent<Animator> ();
		camera = GetComponent<Camera>();

		//Vector3 directionalVector = (nextPosition.position - transform.position).normalized * speed;
	
		// reset lastSqrMag
		lastSqrMag = Mathf.Infinity;

		desiredVelocity = Vector3.zero;
		actionButton = false;

	}

	void Update() {
		actionButton = false;

		if (Input.GetKeyUp (KeyCode.Escape)) {
			if (Application.platform == RuntimePlatform.Android){
				AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
				activity.Call<bool>("moveTaskToBack", true);
			}
			else{
				Application.Quit();
			}

		} else {
			//check click/mouse position on screen
			if(Input.mousePosition.y<2300 && Input.mousePosition.y>260){
				actionButton = Input.anyKeyDown;
			}
		}
		if (nextPosition) {
			Vector3 offset = nextPosition.position - transform.position;
			float sqrLen = offset.sqrMagnitude;
			if (sqrLen < closeDistance * closeDistance) {
				desiredVelocity = Vector3.zero;
				stepSmoke.enableEmission = false;
				moveOn = true;
				animator.SetInteger ("AnimationStat", 0);
			}

		}
		if (actionButton) {   //keyboard
			if(moveOn)
				moveToNextPos ();
		}

		/*
		if (Input.touchCount > 0) {

			Touch myTouch = Input.touches [0];
			if (myTouch.phase == TouchPhase.Began) {
				moveToNextPos ();
			}

		}
		*/
	}
	void PlayMoveSound(){

		audioSource.clip = moveClip;
		audioSource.Play ();
	}

	void moveToNextPos(){
		stepSmoke.enableEmission = true;
		//stepSmoke.Play ();
		animator.SetInteger ("AnimationStat", 1);
		nextPosition.position = new Vector3 (nextPosition.position.x, nextPosition.position.y + 53.3f, nextPosition.position.z);
		Vector3 directionalVector = (nextPosition.position - transform.position).normalized * speed;
		PlayMoveSound ();
		lastSqrMag = Mathf.Infinity;
		desiredVelocity = directionalVector;
		gameManager.SetPlayerScore ();
		if (spwnRoad)
			spwnRoad.AddRoad ();
		DestroyLastRoad ();
		roadAlert.position = new Vector3 (0, roadAlert.position.y + 53.3f, 0);
		print("roadAlert.position.y = " + roadAlert.position.y);
		moveOn = false;
	}

	void DestroyLastRoad(){
		roadDestroyer.position = new Vector3 (0, roadDestroyer.position.y + 53.3f, 0);

	}
	void FixedUpdate() {
		//if(moveOn)

		rigidbody.velocity = desiredVelocity;

	}
}
