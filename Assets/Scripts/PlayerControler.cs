using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour {
	public GameObject[] Laser;
	public Sprite boostSprite;
	public Sprite normalSprite;
	private bool doubleLaser = false; // id 0
	private bool levelUp = false; // id 1
	private bool invinsible = false; // id 2
	private bool boost = false; // id 3
	private bool magnet = false; // id 4

	private float doubleLaserTime = 10;
	private float boostTime = 3;
	private float invinsibleTime = 10;
	private float magnetTime = 10;

	float normalSpeed;
	float normalSpawnTime;

	private ScoreKeeper SK;
	private int baseLevelIndex = 0;
	private int levelIndex;

	public float speed = 5.0f;
	public float beamSpeed = 15.0f;

	public static float xMin;
	public static float xMax;

	public float fireRate;
	private float nextFire;
	float padding = 0.48f;

	public string[] m_tag;

	EnemySpawner ES;

	// Use this for initialization
	void Start () {
		ES = GameObject.Find("enemyFormation").GetComponent<EnemySpawner> ();
		SK = GameObject.Find ("Panel").GetComponent<ScoreKeeper> ();
		Camera camera = Camera.main;
		baseLevelIndex = PlayerPrefs.GetInt ("baseLevel");
		levelIndex = baseLevelIndex;
		xMin = camera.ViewportToWorldPoint (new Vector3 (0, 0)).x +padding;
		xMax = camera.ViewportToWorldPoint (new Vector3 (1, 0)).x -padding;


		normalSpawnTime = ES.spawnTime;

	}

	public bool getBoostStatus(){
		return boost;
	}

	public float getBoostTime(){
		return boostTime;
	}

	public bool getInvisible(){
		return invinsible;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if () {
			if () {
				this.transform.position = new Vector2 (Mathf.Clamp(this.transform.position.x + speed * Time.deltaTime, xMin, xMax) ,this.transform.position.y);
			}
			if () {
				this.transform.position = new Vector2 (Mathf.Clamp(this.transform.position.x - speed * Time.deltaTime, xMin, xMax) ,this.transform.position.y);
			}
		}

		//fire with controll input
		/*
		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			nextFire = fireRate + Time.time;
			GameObject beam = Instantiate (Laser, this.transform.position, Quaternion.identity) as GameObject;
			Rigidbody2D rb = beam.GetComponent<Rigidbody2D> ();
			rb.velocity = new Vector3 (0, beamSpeed, 0);
		}
		*/

		//auto fire
		if(!boost)
			Fire();

		if (doubleLaser) {
			doubleLaserTime -= Time.deltaTime;
			if (doubleLaserTime <= 0) {
				doubleLaser = false;
				doubleLaserTime = 10;
			}
		}

		if (boost) {
			boostTime -= Time.deltaTime;
			this.GetComponent<SpriteRenderer> ().sprite = boostSprite;

			if (boostTime <= 0) {
				boost = false;
				boostTime = 3;
				ES.spawnTime = normalSpawnTime;
				ES.BoostDetected ();
				this.GetComponent<SpriteRenderer> ().sprite = normalSprite;
			}
		}
	}

	void Fire(){
		if (Time.time > nextFire) {
			nextFire = Time.time +fireRate;
			GameObject beam;
			GameObject beam2;

			//for double laser
			Vector2 leftSide = new Vector2(this.transform.position.x+0.5f, this.transform.position.y+0.5f);
			Vector2 rightSide = new Vector2(this.transform.position.x-0.5f, this.transform.position.y+0.5f);
			Vector2 normalPos = new Vector2 (this.transform.position.x, this.transform.position.y+0.5f);

			if(levelUp){
				if (doubleLaser) {
					beam = Instantiate (Laser[levelIndex], leftSide, Quaternion.identity);
					beam2 = Instantiate (Laser[levelIndex], rightSide, Quaternion.identity);
					Rigidbody2D rb2 = beam2.GetComponent<Rigidbody2D> ();
					rb2.velocity = new Vector3 (0, beamSpeed, 0);
				}
				else
					beam = Instantiate (Laser[levelIndex], normalPos, Quaternion.identity);// as GameObject;
			}
			else{
				if (doubleLaser) {
					beam = Instantiate (Laser[baseLevelIndex], leftSide, Quaternion.identity);
					beam2 = Instantiate (Laser[baseLevelIndex], rightSide, Quaternion.identity);
					Rigidbody2D rb2 = beam2.GetComponent<Rigidbody2D> ();
					rb2.velocity = new Vector3 (0, beamSpeed, 0);
				}
				else
					beam = Instantiate (Laser[baseLevelIndex], normalPos, Quaternion.identity);// as GameObject;
			}
				
			Rigidbody2D rb = beam.GetComponent<Rigidbody2D> ();
			rb.velocity = new Vector3 (0, beamSpeed, 0);

		}
	}

	void OnTriggerEnter2D (Collider2D col){
		if (!boost) {
			foreach (string value in m_tag) {
				if (col.CompareTag (value)) {
					Destroy (gameObject);
					SK.StoreHighScore (SK.getScore ());
					SceneManager.LoadScene ("Win Screen");
					return;
				}
			}
		}
		if(col.CompareTag("Coin")){
			int value = 0;
			switch(col.GetComponent<PowerUpScript>().id){
			case 0:
				value = 1;
				break;
			case 1:
				value = 10;
				break;
			}

			Destroy (col.gameObject);
			SK.ScoreCount (value);
		}
		if (col.CompareTag ("PowerUp")) {
			Destroy (col.gameObject);
			if (col.GetComponent<PowerUpScript> ().id == 0){
				doubleLaserTime = 10;
				doubleLaser = true;
			}
			else if(col.GetComponent<PowerUpScript> ().id == 1){
				levelUp = true;
				if(levelIndex < Laser.Length-1)
					levelIndex++;
			}
			else if(col.GetComponent<PowerUpScript> ().id == 3){
				ES.spawnTime = 0.3f;
				boost = true;
				ES.BoostDetected ();
			}
		}
	}

}
