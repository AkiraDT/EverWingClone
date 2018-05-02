using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonAndroidScript : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
				activity.Call<bool>("moveTaskToBack", true);
			}
			else
			{
				Application.Quit();
			}
		}
	}
}
