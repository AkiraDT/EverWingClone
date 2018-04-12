using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public static int score = 0;

	public GameObject mytext;
	public GameObject highScoreText;

	// Use this for initialization
	void Start () {
		Reset ();
		mytext.GetComponent<Text>().text = score.ToString ();
		highScoreText.GetComponent<Text> ().text = PlayerPrefs.GetInt ("highScore").ToString();
	}

	public void ScoreCount(int points){
		score += points;
		mytext.GetComponent<Text>().text = score.ToString ();
	}

	public int getScore(){
		return score;
	}


	public static void Reset(){
		score = 0;
	}

	public void StoreHighScore(int newHighScore){
		int oldHighScore = PlayerPrefs.GetInt ("highScore", 0);
		if (newHighScore > oldHighScore) {
			PlayerPrefs.SetInt ("highScore", newHighScore);
			highScoreText.GetComponent<Text> ().text = newHighScore.ToString();
		}
	}
}
