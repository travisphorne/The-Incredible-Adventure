//2-24-2015
//The Incredible Adventure
//Travis Horne and Zach Schnider

using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	 //array of levels
	//

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name == "Hero" && Hero.S.currentLevel == 2) {
			Application.LoadLevel ("_CONGRATS_"); 
		} else if(collider.gameObject.name == "Hero") {
			PlayerPrefs.SetInt("CurrentScore", Score.S.currentScore);
			Hero.S.currentLevel++;
			Application.LoadLevel (Hero.S.levels [Hero.S.currentLevel]); 
		}
	}
}
