using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject Laser;
	public float fireSpeed = 10.0f;
	private float health = 150.0f;
	private float prob;
	public float enemySpeed = -2f;
	public int scoreValue = 10;
	public GameObject[] dropItem;
	private PlayerControler Player;

	private ScoreKeeper SK;

	private System.Random rand;
	private int dropIndex;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("player").GetComponent<PlayerControler> ();
		SK = GameObject.Find ("Panel").GetComponent<ScoreKeeper> ();
		rand = new System.Random ();
	}
	
	// Update is called once per frame
	void Update () {
		//prob = 0.5f * Time.deltaTime;
		//if (Random.value < prob) {
		//	Fire ();
		//}
		//for enemy movement
		Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, enemySpeed, 0);
		if (health <= 0) {
			Destroy (gameObject);
			dropIndex = rand.Next(dropItem.Length);
			GameObject drop = Instantiate (dropItem[dropIndex], this.transform.position, this.transform.rotation);
		}

		if (Player.getBoostStatus())
			enemySpeed = -15f;
		else
			enemySpeed = -2f;

		if (Player.getBoostTime () <= 0.5)
			health = 0;
	}

	void Fire(){
		GameObject beam = Instantiate (Laser, this.transform.position, Quaternion.identity);
		Rigidbody2D RenderBuffer = beam.GetComponent<Rigidbody2D>();
		RenderBuffer.velocity = new Vector3 (0, -fireSpeed,0);
	}

	void OnTriggerEnter2D (Collider2D col){
		if(col.CompareTag("Bullet")){
			ProjectTile beam = col.gameObject.GetComponent<ProjectTile> ();
			if (beam) {
				health -= beam.GetDamage ();
				beam.Hit ();
			}
		}
		if(col.CompareTag("Player")){
			if (Player.getBoostStatus()) {
				health -= health;
			}
		}
	}
}
