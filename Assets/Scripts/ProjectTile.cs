using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour {

	// Use this for initialization
	public float Damage = 100f;

	public float GetDamage(){
		return Damage;
	}

	public void Hit(){
		Destroy (gameObject);
	}
}