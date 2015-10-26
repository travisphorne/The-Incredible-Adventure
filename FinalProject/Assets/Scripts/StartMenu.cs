using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public void startGame(){
		PlayerPrefs.SetInt ("CurrentScore", 0);
		Application.LoadLevel ("_Scene_0");
	}
}
