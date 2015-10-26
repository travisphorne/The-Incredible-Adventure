//2-24-2015
//The Incredible Adventure
//Travis Horne

using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	public float speed = 1.0f;
	public float jumpSpeed = 0.5f;
	public LayerMask groundLayer;
	
	private Animator EnemyAnimator;
	private Transform gCheck;
	private float scaleX = 1.0f;
	private float scaleY = 1.0f;
	public int moveDirection = -1;

	void Start () {
		EnemyAnimator = GetComponent<Animator>();
		gCheck = transform.FindChild("GCheck");
	}

	void FixedUpdate () {
		//JUMPING
		bool isTouched = Physics.CheckSphere (gCheck.position, 1, groundLayer);
		if (isTouched){
			if (Mathf.Abs(rigidbody.velocity.y) <= 1){
				rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode.Force);
				isTouched = false;
			}
		}

		//WALKING
		if (moveDirection == 1) {
			transform.localScale = new Vector2 (scaleX, scaleY);
		} else if (moveDirection == -1) {
			transform.localScale = new Vector2(-scaleX, scaleY);
		}
		this.rigidbody.velocity = new Vector2(moveDirection * speed, this.rigidbody.velocity.y);
		
		//DEAD
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
}
