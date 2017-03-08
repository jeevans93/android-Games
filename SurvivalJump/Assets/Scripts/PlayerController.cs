using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public float jumpTime;
	private float jumpTimeCounter;
	private float moveSpeedStore;

	//my own code
	//private float speedMilestoneCount2;
	//private float speedDecreaseMilestone;
	//private float speedMilestoneCount2Store;
	//private float speedDecreaseMilestoneStore;
	//private float originalSpeed;
	//public float slowSpeed;
	//private bool flag;
	//own code ends



	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;
	private float suddenSlow;

	private Rigidbody2D myRigidbody;

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
		//myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		//own code
		//speedMilestoneCount2 = speedDecreaseMilestone;
		//speedMilestoneCount2Store = speedMilestoneCount2;
		//speedDecreaseMilestoneStore = speedDecreaseMilestone;
		//slowSpeed = 30;
		//flag = true;
		//originalSpeed = 0;

		//own code ends
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;

		stoppedJumping = true;


	}

	// Update is called once per frame
	void Update () {

		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);


		if (transform.position.x > speedMilestoneCount) {

			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

			moveSpeed =moveSpeed * speedMultiplier;


		}


		//own code

/*			if (originalSpeed < moveSpeed) {

			originalSpeed = moveSpeed;
		}



	if (transform.position.x > slowSpeed ) {

			if (flag == true) {
				slowSpeed = 30;
				flag = false;
			}


			//speedMilestoneCount2 += speedDecreaseMilestone;
			//speedDecreaseMilestone = speedDecreaseMilestone * speedMultiplier * 2;
			moveSpeed = 2;

		}
		if (transform.position.x > slowSpeed + 10) {
			slowSpeed = slowSpeed * 2;
			moveSpeed = originalSpeed;
		}*/



		//own code ends


		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);



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

		if (Input.GetKey (KeyCode.Space) || Input.touchCount==1 && !stoppedJumping) {

			stoppedJumping = true;

			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		if (Input.GetKeyUp (KeyCode.Space)) {

			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (grounded) {

			jumpTimeCounter = jumpTime;
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	}




	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "killbox") {



			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;

			deathSound.Play ();

		}
	}
}