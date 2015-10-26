using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	private Vector3 startPoint;

	public float speed = 1.0f;
	
	private Animator EnemyAnimator;
	private float scaleX = 1.0f;
	private float scaleY = 1.0f;
	public int moveDirection = -1;
	private float distance;

	// Use this for initialization
	void Start () {
		startPoint = this.rigidbody.position;
		moveDirection = Boss.S.moveDirection;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (moveDirection == 1) {
			transform.localScale = new Vector2 (scaleX, scaleY);
		} else if (moveDirection == -1) {
			transform.localScale = new Vector2(-scaleX, scaleY);
		}
		this.rigidbody.velocity = new Vector2(moveDirection * speed, this.rigidbody.velocity.y);

		BoundsCheck ();
	}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "Hero") {
			Hero.S.heroDied();
		}
	}
	
	void BoundsCheck(){
		if (startPoint.x - this.rigidbody.position.x > 10) {
			Destroy (this.gameObject);
			
		} else if (startPoint.x - this.rigidbody.position.x < -10) {
			Destroy (this.gameObject);
		}
	}
}
