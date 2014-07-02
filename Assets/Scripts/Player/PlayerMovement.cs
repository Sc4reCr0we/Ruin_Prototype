using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
		
	public float speed;
	private float maxSpeed;
	public float turnSpeed;
	public int playerNumber = 1;
	private Animator animator;
	private bool canMove = true;
	private bool isPushedback = false;
	private string horizontalInput;
	private string verticalInput;

	
	void Start ()
	{
		maxSpeed = speed;
		if(playerNumber == 1)
		{
			horizontalInput = "Horizontal_Player1";
			verticalInput = "Vertical_Player1";	
		}

		if(playerNumber == 2)
		{
			horizontalInput = "Horizontal_Player2";
			verticalInput = "Vertical_Player2";	
		}
		animator = GetComponent<Animator> ();

	}
	
	void Update () 
	{
		Vector3 direction = new Vector3(0,0,0);
		direction.x 	 += Input.GetAxis (horizontalInput);
		direction.y 	 += Input.GetAxis (verticalInput);



		if (canMove && !isPushedback)

		{
			rigidbody2D.velocity = direction.normalized*speed;
		}
		
		float targetAngle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		
		if (canMove && !isPushedback && (Input.GetAxis(horizontalInput) != 0 || Input.GetAxis (verticalInput) != 0)) 
		{
			
			if(animator.GetBool("moving") == false)
			{
				animator.SetBool("moving", true);
			}
			
			transform.rotation =
				Quaternion.Slerp (transform.rotation,
				                  Quaternion.Euler (0, 0, targetAngle),
				                  turnSpeed * Time.deltaTime);
		}
		else if (animator.GetBool ("moving") == true && !isPushedback) 
		{
			animator.SetBool ("moving", false);
			rigidbody2D.velocity = Vector2.zero;
		}

		
	}
	
	public void stopCasting()
	{
		if (animator.GetBool ("casting") == true) 
		{
			animator.SetBool ("casting", false);
		}
		canMove = false;
		
	}
	
	public void castingEnd()
	{
		canMove = true;
	}

	public void castingEnd2()
	{
		canMove = true;
	}

	public void stopMoving()
	{
		canMove = false;
	}

	public void slowDown(float amount)
	{
		amount /= 100f;
		speed = maxSpeed * amount;
		
	}

	public void setSpeedNormal()
	{
		speed = maxSpeed;
	}

	public void setPushedback(float dist){
		isPushedback = true;
		calcPushTime (dist);
	}

	public void setPushStop(){
		isPushedback = false;
		}

	private void calcPushTime(float dist){
		float speedTemp;
		float timeTemp;
		speedTemp = rigidbody2D.velocity.magnitude;

		timeTemp = dist / speedTemp;
		if (isPushedback) {
			Invoke("setPushStop",1f);
				}
	}
}