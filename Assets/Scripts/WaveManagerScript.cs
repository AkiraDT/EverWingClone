using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManagerScript : MonoBehaviour {
	
	public GameObject timeText;
	public float n_enemySpeed;
	public float n_enemyHealth;

	private bool wave = false;
	private float time;
	private int roundTime;
	private EnemySpawner enemySpawner;
	private SweeperSpawnerScript sweeperSpawner;
	private SweeperSpawnerScript disturberSpawner;
	// Use this for initialization
	void Start () {
		enemySpawner = GameObject.Find ("enemyFormation").GetComponent<EnemySpawner>();
		sweeperSpawner = GameObject.Find ("SweeperSpawner").GetComponent<SweeperSpawnerScript>();
		disturberSpawner = GameObject.Find ("DisturbingEnemySpawner").GetComponent<SweeperSpawnerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		roundTime = (int)time;
		timeText.GetComponent<Text> ().text = roundTime.ToString ();

		if (roundTime % 30 == 0) {
			if (wave) {
				Debug.Log ("wave :" + roundTime / 30);
				enemySpawner.spawnTime -= 0.2f;
				sweeperSpawner.minTime -= 1f;
				disturberSpawner.minTime -= 1f;
				n_enemySpeed -= 0.2f;
				n_enemyHealth += 40;
				enemySpawner.WaveChanged ();
				wave = false;			
			}
			wave = false;
		} else
			wave = true;
	}
}
