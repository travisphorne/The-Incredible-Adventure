using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "Hero") {
			Hero.S.heroDied();
		}
	}
}
