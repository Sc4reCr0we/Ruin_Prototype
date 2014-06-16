using UnityEngine;
using System.Collections;

public class ArenaStateController : MonoBehaviour {
	public float firstStateChangeTimer;
	public float secondStateChangeTimer;
	public float thirdStateChangeTimer;
	public float colliderRadiusSpeed;
	private bool isState4 = false;
	
	private float colliderRadius;
	private Animator animator;
	private CircleCollider2D collider;
	private string currentState = "state_1";

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		collider = GetComponent<CircleCollider2D> ();
		colliderRadius = collider.radius;
		Invoke ("isState_2", firstStateChangeTimer);
		Invoke ("isState_3", secondStateChangeTimer);
		Invoke ("isState_4", thirdStateChangeTimer);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(currentState == "state_2")
			collider.radius = Mathf.Lerp (collider.radius, colliderRadius * 0.75f, colliderRadiusSpeed * Time.deltaTime);

		if(currentState == "state_3")
			collider.radius = Mathf.Lerp (collider.radius, colliderRadius * 0.5f, colliderRadiusSpeed * Time.deltaTime);

		if(currentState == "state_4")
			collider.radius = Mathf.Lerp (collider.radius, colliderRadius * 0.25f, colliderRadiusSpeed * Time.deltaTime);
	
	}

	public void isState_2()
	{
		animator.SetBool ("isState_2", true);
		currentState = "state_2";


	}

	public void isState_3()
	{

		animator.SetBool ("isState_3", true);
		currentState = "state_3";
	}

	public void isState_4()
	{
		isState4 = true;
		animator.SetBool ("isState_4", true);
		currentState = "state_4";
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
			collider.GetComponent<OutsideArenaDamage>().isOutside = false;

	}
	
	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
			collider.GetComponent<OutsideArenaDamage>().isOutside = true;
	}

	public bool getState(){
		return isState4;
	}
}
