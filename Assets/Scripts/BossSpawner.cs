using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
	public GameObject boss;
	private GameObject Player;
	private GameObject enemySpawner;
	private int direction = 1;
	private float width = 9.5f;
	private float height = 7.0f;
	public float spawnTime = 30f;
	private int spesialPlace;	//for enemyS placing
	private System.Random rand;

	// Use this for initialization
	void Start () {
		rand = new System.Random();
		Player = GameObject.Find ("player");
		enemySpawner = GameObject.Find ("enemyFormation");
	}

	public void BoostDetected(){
		//CancelInvoke ("SpawnEnemies");
		//Invoke("SpawnEnemies", spawnTime);
	}

	void SpawnBoss(){
		foreach (Transform child in this.transform) {
			GameObject spawn;
			spawn = Instantiate (boss, child.transform.position, Quaternion.identity);// as GameObject;
			spawn.transform.parent = child.transform;

		}

	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube(this.transform.position, new Vector3(width,height));
	}

	void Update(){
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0 && !Player.GetComponent<PlayerControler>().getBoostStatus()) {
			SpawnBoss ();
			spawnTime = 30;
			enemySpawner.SetActive (false);
		}
	}
}
