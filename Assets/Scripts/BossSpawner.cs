using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
	public GameObject boss;
	private GameObject Player;
	private GameObject enemySpawner;
	private GameObject sweeperSpawner;
	private GameObject disturberSpawner;
	private int direction = 1;
	public float spawnTime = 30f;
	private System.Random rand;

	// Use this for initialization
	void Start () {
		rand = new System.Random();
		Player = GameObject.Find ("player");
		enemySpawner = GameObject.Find ("enemyFormation");
		sweeperSpawner = GameObject.Find ("SweeperSpawner");
		disturberSpawner = GameObject.Find ("DisturbingEnemySpawner");
	}

	void SpawnBoss(){
		foreach (Transform child in this.transform) {
			Instantiate (boss, this.transform.position, Quaternion.identity);// as GameObject;
		}

	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube(this.transform.position, new Vector3(9.5f, 7.0f));
	}

	void Update(){
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0 && !Player.GetComponent<PlayerControler>().getBoostStatus()) {
			SpawnBoss ();
			spawnTime = 30;
			enemySpawner.SetActive (false);
			sweeperSpawner.SetActive (false);
			disturberSpawner.SetActive (false);
		}
	}
}
