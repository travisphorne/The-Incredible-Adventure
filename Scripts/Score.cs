//2-24-2015
//The Incredible Adventure
//Travis Horne

using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	static public Score S;
	public int highScore;
	public int currentScore;
	
	void Start () {
		S = this;
		//if currentScore exists then set the current game score to the playerprefs currentscore
		//else create playerprefs currentScore
		if(PlayerPrefs.HasKey("CurrentScore")){
			currentScore = PlayerPrefs.GetInt ("CurrentScore");
		} else {
			PlayerPrefs.SetInt ("CurrentScore", 0);
			currentScore = 0;
		}

		if (!PlayerPrefs.HasKey ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", currentScore);
		} else {
			highScore = PlayerPrefs.GetInt ("HighScore");
		}
	}

	void Update () {
		if (currentScore > highScore) {
			highScore = currentScore;
			PlayerPrefs.SetInt ("HighScore", currentScore);
		}
	}
}

