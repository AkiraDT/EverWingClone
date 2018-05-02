using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveClearUI : MonoBehaviour {
	private int count;
	private float delay = 0.5F;


	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (count > 0) {
			//play script
			delay -= Time.deltaTime;
			this.GetComponent<Animator>().Play("WaveClearAnimation");

			if (delay <= 0 && count > 1) {
				delay = 0.5f;
				count--;
				this.GetComponent<Animator>().Play("New State");
			}

		}
	}
		
	public void increaseCount(){
		count++;
	}
}
