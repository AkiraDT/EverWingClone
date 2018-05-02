using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperLineScript : MonoBehaviour {
	private float sweeperLineSpeed = 0.3f;
	private float time;
	private float spawnTimer;
	private GameObject Player;
	public GameObject Meteorit;
	public float fireSpeed = 5.0f;
	private float direction;


	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("player");
		spawnTimer = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= spawnTimer && !Player.GetComponent<PlayerControler>().getBoostStatus()) {
			Fire ();
		}
		if (Player.transform.position.x < this.transform.position.x) {
			direction = -1;
		} else if (Player.transform.position.x > this.transform.position.x) {
			direction = 1;
		} else {
			direction = 0;
		}

		this.transform.position += new Vector3 (sweeperLineSpeed * direction * Time.deltaTime, 0f, 0f);
	}

	void Fire(){
		GameObject beam = Instantiate (Meteorit, this.transform.position, Quaternion.identity);
		Rigidbody2D RenderBuffer = beam.GetComponent<Rigidbody2D>();
		RenderBuffer.velocity = new Vector3 (0, -fireSpeed,0);
		Destroy (this.gameObject);
	}
}
