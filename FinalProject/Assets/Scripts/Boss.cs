using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	static public Boss S;
	private float speed = 4.0f;
	
	private Animator EnemyAnimator;
	private float scaleX = 1.0f;
	private float scaleY = 1.0f;
	public int moveDirection = -1;
	private float distance;
	private int muhInt;
	private Vector3 muhVector;

	// Use this for initialization
	void Awake () {
		S = this;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		muhInt = Random.Range (1, 25);
		//CHANGING DIRECTIOn
		if (muhInt % 9 == 0) {
			if(moveDirection == -1){
				moveDirection = 1;
			}else if(moveDirection == 1){
				moveDirection =  -1;
			}
		}

		//PROJECTILE SHIT
		if (muhInt % 24 == 0) {
			muhVector = this.rigidbody.position;
			muhVector.y -= .5f;
			Instantiate(Resources.Load("Projectile"), muhVector,  Quaternion.identity);
		}

	
		//WALKING
		if (moveDirection == 1) {
			transform.localScale = new Vector2 (scaleX, scaleY);
		} else if (moveDirection == -1) {
			transform.localScale = new Vector2(-scaleX, scaleY);
		}
		this.rigidbody.velocity = new Vector2(moveDirection * speed, this.rigidbody.velocity.y);
		
		//DEAD
		BoundsCheck ();
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "Hero") {
			if(collision.rigidbody.position.y - this.rigidbody.position.y > 0.3){
				Destroy(this.gameObject);
				Score.S.currentScore += 25;
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
	
	void BoundsCheck(){
		if (this.rigidbody.position.y < -5) {
			Destroy (this.gameObject);
			
		}
	}
}
