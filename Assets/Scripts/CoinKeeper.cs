using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinKeeper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = PlayerPrefs.GetInt ("coin").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
