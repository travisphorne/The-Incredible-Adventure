using UnityEngine;
using System.Collections;

public class ButtonDrop : MonoBehaviour {
	
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name == "Hero"){
			Destroy(GameObject.FindWithTag("Box1"));
			Destroy(GameObject.FindWithTag ("Button1")); 
		}
	}
}
