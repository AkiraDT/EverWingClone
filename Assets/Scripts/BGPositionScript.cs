using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGPositionScript : MonoBehaviour {
	private Transform[] layers;
	private int bottomIndex;
	private int aboveIndex;
	private float viewZone = 10f;
	public float bgSize;
	private Transform cameraTransform;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			layers[i] = transform.GetChild(i);
		}
		bottomIndex = 0;
		aboveIndex = layers.Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraTransform.position.y < (layers [bottomIndex].transform.position.y + viewZone)) {
			Reposition ();
		}
	}

	void Reposition(){
		layers [bottomIndex].position = Vector2.up * (layers [aboveIndex].position.y + bgSize);
		aboveIndex = bottomIndex;
		bottomIndex++;
		if(bottomIndex == layers.Length){
			bottomIndex = 0;
		}
	}
}
