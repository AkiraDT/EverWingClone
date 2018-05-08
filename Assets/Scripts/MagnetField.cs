using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("PowerUp") || col.CompareTag("Coin")){
			col.gameObject.transform.position = Vector2.MoveTowards (col.gameObject.transform.position, this.transform.parent.transform.position, 7 * Time.deltaTime);
		}
	}
}
