using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {
	private float powerUpSpeed = -5f;
	public int id = 0;
	private GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, powerUpSpeed, 0);


		if (Player.GetComponent<PlayerControler> ().Magnet) {
			this.transform.position = Vector2.MoveTowards (this.transform.position, Player.transform.position, 1.5f * Time.deltaTime);
		}

	}
		
		
}
