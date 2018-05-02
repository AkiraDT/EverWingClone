using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveObserver : MonoBehaviour {
	public GameObject waveSign;
	private PlayerControler Player;
	private int counter = 5;
	private ScoreKeeper SK;
	public float enemySpeed = -2f;
	private float initialSpeed;
	private WaveClearUI WaveUI;

	// Use this for initialization
	void Awake () {
		Player = GameObject.Find("player").GetComponent<PlayerControler> ();
		SK = GameObject.Find ("Panel").GetComponent<ScoreKeeper> ();
		initialSpeed = enemySpeed;
		WaveUI = GameObject.Find ("WaveClear").GetComponent<WaveClearUI>();
	}
	
	// Update is called once per frame
	void Update () {
		if (counter <= 0) {
			SK.ScoreCount (2);
			WaveUI.increaseCount ();
			Destroy (this.gameObject);
			return;
		}

		Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, enemySpeed, 0);

		if (Player.getBoostStatus())
			enemySpeed = -30f;
		else
			enemySpeed = initialSpeed;

		//if (Player.getBoostTime () <= 0.5)
		//	Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "ObjectDestroyer") {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.CompareTag("Enemy")){
			counter--;
		}
	}
}
