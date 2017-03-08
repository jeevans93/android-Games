using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public float jumpTime;
	private float jumpTimeCounter;
	private float moveSpeedStore;

	/*public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;
	private float suddenSlow;*/

	private Rigidbody2D myRigidbody;
	private Rigidbody2D myRigidbody1;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	private bool stoppedJumping;
	private bool canDoubleJump;

	//private Collider2D myCollider;

	private Animator myAnimator;

	public GameManager theGameManager;

	public AudioSource jumpSound;
	public AudioSource deathSound;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody2D>();
		myRigidbody1 = GetComponent<Rigidbody2D>();
		//myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;

	//	speedMilestoneCount = speedIncreaseMilestone;

/*		//own code
		//speedMilestoneCount2 = speedDecreaseMilestone;
		//speedMilestoneCount2Store = speedMilestoneCount2;
		//speedDecreaseMilestoneStore = speedDecreaseMilestone;
		slowSpeed = 30;
		flag = true;
		originalSpeed = 0;*/

		//own code ends
		moveSpeedStore = moveSpeed;
	//	speedMilestoneCountStore = speedMilestoneCount;
	//	speedIncreaseMilestoneStore = speedIncreaseMilestone;

		stoppedJumping = true;


	}

	// Update is called once per frame
	void Update () {

		//joystick

		//Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"),CrossPlatformInputManager.GetAxis ("Vertical"))* moveSpeed;
		//bool isJumping = CrossPlatformInputManager.GetButton ("Jump");
		//Debug.Log (isJumping ? jumpForce : 1);
		//myRigidbody.AddForce (moveVec*((isJumping ? jumpForce : 1)));

		//joy stcik
		
			//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

			grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);


	/*	if (transform.position.x > speedMilestoneCount) {
		
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

			moveSpeed =0;
				
		
		}*/



		myRigidbody.velocity = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal")*moveSpeed, myRigidbody1.velocity.y);
		//myRigidbody.velocity = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"),CrossPlatformInputManager.GetAxis ("Vertical"))* moveSpeed;
	

		if (Input.GetKeyDown (KeyCode.Space) || Input.touchCount == 1) {

				if (grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
					stoppedJumping = false;
				jumpSound.Play ();
				}
			if (!grounded && canDoubleJump) {
			
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter = jumpTime;
				stoppedJumping = false;
				canDoubleJump = false;
				jumpSound.Play ();
			
			}
			}

	//	bool isJumping = CrossPlatformInputManager.GetButton ("Jump");
	//	Debug.Log (isJumping ? jumpForce : 1);
	//	myRigidbody.AddForce ((new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"),CrossPlatformInputManager.GetAxis ("Vertical"))* moveSpeed)*((isJumping ? jumpForce : 1)));



		if (Input.GetKey (KeyCode.Space) || Input.touchCount==1 && !stoppedJumping) {

			stoppedJumping = true;

				if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
					jumpTimeCounter -= Time.deltaTime;
				}
			}
		if (Input.GetKeyUp (KeyCode.Space)|| Input.touchCount==1) {
		
				jumpTimeCounter = 0;
				stoppedJumping = true;
			}

			if (grounded) {
		
				jumpTimeCounter = jumpTime;
			}

		myAnimator.SetFloat ("Speed",myRigidbody.velocity.x);
			myAnimator.SetBool ("Grounded", grounded);
		}



	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "killbox") {

			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			//speedMilestoneCount = speedMilestoneCountStore;
			// = speedIncreaseMilestoneStore;

			deathSound.Play ();
		
		}
	}
}

