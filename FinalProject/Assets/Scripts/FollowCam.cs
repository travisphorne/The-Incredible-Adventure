using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int distance = 10;
		if (GameObject.Find ("Hero")) {
			Vector3 PlayerPOS = GameObject.Find ("Hero").transform.transform.position; 
			GameObject.Find ("MainCamera").transform.position = new Vector3(PlayerPOS.x - 3, 5, PlayerPOS.z -distance);
		}
	}
}
