using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class BossAnimationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Load data
		UnityFactory.factory.LoadDragonBonesData("Boss/Boss_ske");
		UnityFactory.factory.LoadTextureAtlasData ("Boss/Boss_tex");

		//create armature
		var armatureComponent = UnityFactory.factory.BuildArmatureComponent("Boss");

		armatureComponent.animation.Play ("animtion0");

		armatureComponent.transform.localPosition = new Vector3 (0f,0f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
