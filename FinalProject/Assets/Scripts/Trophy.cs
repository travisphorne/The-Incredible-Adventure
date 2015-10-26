﻿using UnityEngine;
using System.Collections;

public class Trophy : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.name == "Hero"){
			Score.S.currentScore += 1000;
			//MAKE A NOISE
			Destroy (this.gameObject);
		}
	}
}