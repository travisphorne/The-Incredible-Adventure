using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collider){
				if (collider.gameObject.name == "Hero") { 
					Destroy (GameObject.FindWithTag("Destructable"),1.5f); 

				}
		}		

}
