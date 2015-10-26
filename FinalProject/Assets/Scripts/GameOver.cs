using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Text highScoreText;
	public Text scoreText;

	void Update () {
		highScoreText.text = "HighScore: " + (Score.S.highScore);
		scoreText.text = "Score: " + (Score.S.currentScore);
	}

	public void retry () {
		PlayerPrefs.SetInt("CurrentScore", 0);
		Application.LoadLevel ("_Scene_0");
	}
}
