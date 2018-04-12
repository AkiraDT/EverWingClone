using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreder : MonoBehaviour {

	public string[] m_tag;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		foreach (string value in m_tag) {
			if (other.CompareTag (value)) {
				Destroy (other.gameObject);
				return;
			}
		}

	}
}
