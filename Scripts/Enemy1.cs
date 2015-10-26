//2-24-2015
//The Incredible Adventure
//Travis Horne

using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {
	public float speed = 1.0f;

	private Animator EnemyAnimator;
	private float scaleX = 1.0f;
	private float scaleY = 1.0f;
	public int moveDirection = -1;
	private float distance;

	// Use this for initialization
	void Start () {
		EnemyAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (moveDirection == 1) {
			transform.localScale = new Vector2 (scaleX, scaleY);
		} else if (moveDirection == -1) {
			transform.localScale = new Vector2(-scaleX, scaleY);
		}
		this.rigidbody.velocity = new Vector2(moveDirection * speed, this.rigidbody.velocity.y);

		//initializeEnemy ();

		BoundsCheck (EnemyAnimator);
	}


	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "Hero") {
			if(collision.rigidbody.position.y - this.rigidbody.position.y > 0.3){
				Destroy(this.gameObject);
				Score.S.currentScore += 100;
			} else {
				Hero.S.heroDied();
			}
		}
		if (moveDirection == -1) {
			moveDirection = 1;
		}
		else if(moveDirection == 1){
			moveDirection = -1;
		}
	}

	void BoundsCheck(Animator myAnimator){
		if (myAnimator.rigidbody.position.y < -5) {
			Destroy (this.gameObject);
			
		}
	}
	/*
	void initializeEnemy(){
		distance = this.transform.position.x - Hero.S.transform.position.x;
		print (distance);

		if (distance > -10) {
			print ("it's happening");
			this.gameObject.SetActive (true);
		} else if (distance > -10) {
			print ("it's not happening");
			this.gameObject.SetActive (false);
		}
	}
	*/
}
