//2-24-2015
//The Incredible Adventure
//Travis Horne and Zach Schnider

using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	static public Hero S;
	public float speed = 1.0f;
	public float runSpeed = 1.0f;
	public float jumpSpeed = 100f;
	public static int lives = 3;
	public string[] levels = {"_Scene_0", "_Scene_1", "_Scene_2"};
	public int currentLevel = 0;
	public LayerMask groundLayer;
	
	private Animator HeroAnimator;
	private Transform gCheck;
	private float scaleX = 1.0f;
	private float scaleY = 1.0f; 
	private float initialSpeed = 1.0f;
	
	void Start () {
		S = this;
		HeroAnimator = GetComponent<Animator>();
		gCheck = transform.FindChild("GCheck");
		initialSpeed = speed;
	}  
	
	void FixedUpdate () {
		float mSpeed = Input.GetAxis("Horizontal");
		HeroAnimator.SetFloat("Speed", Mathf.Abs(mSpeed));

		bool isTouched = Physics.CheckSphere (gCheck.position, 1, groundLayer);

		//JUMPING
		if (Input.GetKey(KeyCode.Space)){
			
			if (isTouched){
				if (Mathf.Abs(rigidbody.velocity.y) <= 1){
					rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode.Force);
					isTouched = false;
				}
			}
		}
		HeroAnimator.SetBool("isTouched", isTouched);

		//RUNNING
		if(Input.GetKey(KeyCode.Z) && speed == initialSpeed){
			speed = runSpeed;
		}
		if (!Input.GetKey (KeyCode.Z) && speed != initialSpeed) {
			speed = initialSpeed;
		}

		//WALKING
		if (mSpeed > 0){
			transform.localScale = new Vector2(scaleX, scaleY);
		}
		else if (mSpeed < 0){
			transform.localScale = new Vector2(-scaleX, scaleY);
		}
		
		this.rigidbody.velocity = new Vector2(mSpeed * speed, this.rigidbody.velocity.y);


		BoundsCheck(HeroAnimator);
	}

	void BoundsCheck(Animator myAnimator){
		if (myAnimator.rigidbody.position.y < -5) {
			heroDied ();
		}
	}
	public void heroDied(){
		lives -= 1;
		Destroy (this.gameObject);
		
		if (lives > 0) {
			PlayerPrefs.SetInt("CurrentScore", Score.S.currentScore);
			PlayerPrefs.SetInt("HighScore", Score.S.highScore);
			Application.LoadLevel (levels[currentLevel]);
		} else if (lives == 0){
			Hero.lives = 3;
			Hero.S.currentLevel = 0;
			Application.LoadLevel ("_GAMEOVER_");
		}
	}
}
