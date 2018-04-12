using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;
	public GameObject enemyS;	//Unique enemy
	private int direction = 1;
	private float width = 9.5f;
	private float height = 7.0f;
	public float spawnTime = 1.5f;
	private int counter = 5;
	private int spesialPlace;	//for enemyS placing
	private System.Random rand;
	private int maxCount = 6;

	// Use this for initialization
	void Start () {
		rand = new System.Random();
		//InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
		Invoke("SpawnEnemies", spawnTime);
	}

	public void BoostDetected(){
		CancelInvoke ("SpawnEnemies");
		Invoke("SpawnEnemies", spawnTime);
	}

	void SpawnEnemies(){
		counter = 5;
		spesialPlace = rand.Next(1, maxCount);
		foreach (Transform child in this.transform) {
			GameObject spawn;
			if(counter == spesialPlace)
				spawn = Instantiate (enemyS, child.transform.position, Quaternion.identity);// as GameObject;
			else
				spawn = Instantiate (enemy, child.transform.position, Quaternion.identity);// as GameObject;
			spawn.transform.parent = child.transform;
			counter--;
		}
		Invoke("SpawnEnemies", spawnTime);
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube(this.transform.position, new Vector3(width,height));
	}

	// Update is called once per frame
	void Update () {
		//This code is for moving the enemy right and left
		/*
		float FormationRightEdge = this.transform.position.x + 0.5f * width;
		float FormationLeftEdge = this.transform.position.x - 0.5f * width;

		if (FormationRightEdge > PlayerControler.xMax) {
			direction = -1;
		}
		if (FormationLeftEdge < PlayerControler.xMin) {
			direction = 1;
		}

		this.transform.position += new Vector3(direction * enemySpeed * Time.deltaTime,0f,0f);
		*/
	}
}
