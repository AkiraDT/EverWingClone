using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour {
	
	public Image healthBarBG;
	public Image healthBar;
	public GameObject[] dropItem;
	public float health = 150.0f;
	public float bossSpeed = -2f;
	public float fireSpeed = 10.0f;
	public bool canShot;
	public GameObject Laser;

	private Animator anim;
	private PlayerControler Player;
	private float maxHealth;
	private float prob;
	private float initialSpeed;
	private System.Random rand;
	private int dropIndex;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("player").GetComponent<PlayerControler> ();
		if (Player == null)
			return;
		healthBarBG.enabled = false;
		healthBar.enabled = false;
		initialSpeed = bossSpeed;
		anim = this.transform.GetComponentInParent<Animator> ();
		anim.Play ("BossEnterAnimation");
	}

	void Awake(){
		rand = new System.Random ();
		maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		//Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();
		//rb.velocity = new Vector3 (0, bossSpeed, 0);

		if (health <= 0) {
			Destroy (gameObject);
			if (dropItem.Length > 1)
				dropIndex = rand.Next (dropItem.Length);
			//Debug.Log ("drop:"+dropIndex+" length:"+dropItem.Length);
			Instantiate (dropItem[dropIndex], this.transform.position, this.transform.rotation);
		}

		if(canShot){
			Fire ();
		}
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
				healthBarBG.enabled = true;
				healthBar.enabled = true;
				beam.Hit ();
				healthBar.fillAmount =  health/maxHealth;
			}
		}
	}
}
