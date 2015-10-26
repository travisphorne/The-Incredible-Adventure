//2-24-2015
//The Incredible Adventure
//Travis Horne

using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {	

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.name == "Hero"){
			Score.S.currentScore += 100;

			if(Score.S.currentScore % 1000 == 0){
				Hero.lives++;
			}

			Destroy (this.gameObject);
		}
	}
}
