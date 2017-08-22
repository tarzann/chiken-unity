using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarHit : MonoBehaviour {


	private AudioSource audioSource; 
	public AudioClip dieClip;
	public GameObject gameManagerObj;
	private GameManagerScript gameManager;
	private UserXP userXP;
	private TimeManager timeManager;
	public ParticleSystem poof;
	public ParticleSystem hitSmoke;
	public ParticleSystem partiShield;
	public ParticleSystem partiStartShield;
	public ParticleSystem partiInvisible;
	public bool powerUpActive = false;
	public bool shieldActive = false;
	public bool invisibleActive = false;
	public float shieldTime = 10f;
	public float InvisibleTime = 10f;


	private Renderer renderer;

	void Awake(){

		StopAllParticles ();
	}

	// Use this for initialization
	void Start () {
		poof.enableEmission = false;
		gameManager = gameManagerObj.GetComponent<GameManagerScript> ();
		userXP = gameManagerObj.GetComponent<UserXP> ();
		timeManager = gameManagerObj.GetComponent<TimeManager> ();
		audioSource = GetComponent<AudioSource> ();
		renderer = GetComponent<Renderer> ();
		//poof.GetComponent<ParticleSystem> ().particleEmitter = false;
		StopAllParticles();
	
	}
	void StopAllParticles(){
		hitSmoke.Stop ();
		poof.Stop ();
		partiShield.Stop ();
		partiStartShield.Stop ();
		partiInvisible.Stop ();
	}
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target){
		if (gameObject != null) {
			if (target.gameObject.tag == "Car") {
				if (!powerUpActive) {
					print ("Hit");
					gameManager.CheckBestScore ();
					userXP.UpdateXP(PlayerPrefs.GetInt("roundScore"));
					gameObject.GetComponent<Renderer> ().enabled = false;
					ShowPoof ();
					PlayDieSound ();
				} else {
					if(shieldActive)
						StartCoroutine(ShiledOff(0.5f));
				}
			}

		}
	}

	void ShowPoof(){
//		poof.Emit
//		poof.transform = new Vector3 (transform.x, transform.y, transform.z);
		hitSmoke.Play();
		poof.enableEmission = true;
		poof.Play ();
	}
	void PlayDieSound(){

		audioSource.clip = dieClip;
		audioSource.Play ();
	}
	public void ShiledOn(){
		if (!shieldActive) {
			partiStartShield.Play();
			powerUpActive = true;
			shieldActive = true;
			StartCoroutine(ShiledOff(shieldTime));
			partiShield.Play ();
		}
	}
	IEnumerator ShiledOff(float _delay){
		yield return new WaitForSeconds(_delay);
		powerUpActive = false;
		shieldActive = false;
		partiShield.Stop ();
	}
	public void InvisibleOn(){
		partiInvisible.Play ();
		powerUpActive = true;
		invisibleActive = true;
		Color tmp = GetComponent<SpriteRenderer>().color;
		tmp.a = 0.5f;
		GetComponent<SpriteRenderer>().color = tmp;
		StartCoroutine (InvisibleOff (InvisibleTime));
		//partiInvisible.Stop ();
	}
	IEnumerator InvisibleOff(float _delay){
		yield return new WaitForSeconds(_delay);
		Color tmp = GetComponent<SpriteRenderer>().color;
		for(var n = 0; n < 5; n++){
			tmp.a = 0.5f;
			GetComponent<SpriteRenderer> ().color = tmp;
			yield return new WaitForSeconds (0.1f);
			tmp.a = 1;
			GetComponent<SpriteRenderer> ().color = tmp;
			yield return new WaitForSeconds (0.1f);
		}
		powerUpActive = false;
		invisibleActive = false;

	}

}
