using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour {
	private BoxCollider2D col;
	private PlayerControler player;
	private float bgHeight;
	private Rigidbody2D rb;
	public float bgSpeed = -0.2f;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player").GetComponent<PlayerControler> ();
		rb = this.GetComponent<Rigidbody2D> ();
		col = this.GetComponent<BoxCollider2D> ();
		bgHeight = col.size.y;
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (0f, bgSpeed);
		if(transform.position.y < -bgHeight+8){
			Reposition ();
		}
		if (player.getBoostStatus () == true) {
			bgSpeed = -1.5f;
		} else {
			bgSpeed = -0.2f;
		}
	}

	void Reposition(){
		Vector3 bgOffSet = new Vector3 (0f, bgHeight*2 - 7f, 0f);
		this.transform.position = (Vector3)transform.position + bgOffSet;
	}
}
