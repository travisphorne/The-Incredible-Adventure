//2-24-2015
//The Incredible Adventure
//Travis Horne

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Text levelText; 
	public Text scoreText;
	public Text livesText;

	void Update () {
		levelText.text = "Level: " + (Hero.S.currentLevel + 1);
		scoreText.text = "Score: " + (Score.S.currentScore);
		livesText.text = "Lives: " + (Hero.lives);
	}
}
