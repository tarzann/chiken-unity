using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveiTween : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip moveClip;

	public Transform roadDestroyer;
	public Transform nextPosition;
	public Transform roadAlert;
	public double stepSpeed = 0.3f;
	private Rigidbody2D rigidbody;
	public bool actionButton = false;
	public bool moveOn = true;
	public string easeinType = "easeInQuad";
	private int userAverageScore;

	public GameObject roadsObj;
	private SpwnRoad spwnRoad;

	public GameObject gameManagerObj;
	private GameManagerScript gameManager;
	private Animator animator;
	public ParticleSystem stepSmoke;

	public GameObject presentObj;
	private int presentRndRoad;
	Camera camera;



	public float closeDistance = 2.0F;


	void Awake(){

	}
	void Start(){
		stepSmoke.enableEmission = false;
		rigidbody = GetComponent<Rigidbody2D> ();
		gameManager = gameManagerObj.GetComponent<GameManagerScript> ();
		spwnRoad = roadsObj.GetComponent<SpwnRoad> ();
		audioSource = GetComponent<AudioSource> ();
		animator = GetComponent<Animator> ();
		camera = GetComponent<Camera>();
		actionButton = false;
		moveOn = true;
		userAverageScore = PlayerPrefs.GetInt ("userAverageScore");
		if (userAverageScore > 12) {
			var tempRnd = Random.Range (userAverageScore - 10, userAverageScore + 10);
			presentRndRoad = (int)tempRnd;
		} else {
			presentRndRoad = 10;
		}
		
		print ("presentRndRoad = " + presentRndRoad);
		//animator.SetInteger ("AnimationStat", 1);
		presentObj.transform.position = new Vector3(0f,(presentRndRoad*53.3f)-14f,0f);
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

		if (actionButton) {   //keyboard
			
			if (moveOn) {
				print ("CLICK");
				moveToNextPos ();
			}
		}

	}
	void PlayMoveSound(){

		audioSource.clip = moveClip;
		audioSource.Play ();
	}

	void moveToNextPos(){
		
		stepSmoke.enableEmission = true;
		animator.SetInteger ("AnimationStat", 1);
		iTween.MoveBy(gameObject,iTween.Hash("y", 53.3f,"easeType", easeinType,"time", stepSpeed,"oncomplete","StopMovingAnim"));

		PlayMoveSound ();
		gameManager.SetPlayerScore ();
		if (spwnRoad)
			spwnRoad.AddRoad ();
		DestroyLastRoad ();
		moveOn = false;
	}
	void StopMovingAnim(){
		animator.SetInteger ("AnimationStat", 0);
		stepSmoke.enableEmission = false;
		moveOn = true;
	}

	void DestroyLastRoad(){
		roadDestroyer.position = new Vector3 (0, roadDestroyer.position.y + 53.3f, 0);
		roadAlert.position = new Vector3 (0, roadAlert.position.y + 53.3f, 0);
	}
	void FixedUpdate() {
		
	}
}
