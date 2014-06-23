using UnityEngine;
using System.Collections;

public class Gust_Behaviour : MonoBehaviour {
	public float range;
	public float speed;
	public float damage;
	public float pushback;
	public float pushStack;
	public GameObject playerID;
	public Transform instance;
	public float angle;
	public float charge = 0f;
	public bool smartCast = false;

	private float MaxChargeTime;
	private float MaxCharge = 1;
	private float currentPush;
	private float currentStack;
	private float chargePerSec;
	private Vector3 targetPosition;
	private bool startedCharge = false;
	private bool hasFired = false;
	public float castTurnSpeed;

	// Use this for initializationd
	void Start () {

	}

	void killMe(){
		Destroy (gameObject);
	}
	
	// Update is called once per framee
	void Update () {
		if (Input.GetButton ("Mouse1")) {
			playerID.GetComponent<PlayerMovement>().stopMoving();
			if(charge < MaxCharge)
			charge += chargePerSec * Time.deltaTime;
			if (!startedCharge)
				startedCharge = true;
			if(charge >= MaxCharge)
				Debug.Log("Full charge!");
		}

		if (!Input.GetButton ("Mouse1") && startedCharge && !hasFired) {
			instanceCreate();
		}
	}

	public void onCast (float maximumChargeTime, bool smartcast ) {
		MaxChargeTime = maximumChargeTime;
		chargePerSec = MaxCharge / MaxChargeTime;
		smartCast = smartcast;
	}

	public void instanceCreate(){
		hasFired = true;
		targetPosition = playerID.GetComponent<slotManager> ().targetPos ();
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos 		= targetPosition;
		Vector3 gustDir		= mousePos - currentPosition;
		gustDir.z 			= 0;
		gustDir.Normalize ();
		
		float angle 					= Mathf.Atan2 (gustDir.y, gustDir.x) * Mathf.Rad2Deg;
		var gustID2 					= Instantiate (instance, currentPosition + gustDir/2, Quaternion.identity) as Transform ;
		
		gustID2.GetComponent<Gust_Behaviour2> ().onCast (gustDir,speed,angle,range*charge);
		gustID2.GetComponent<Gust_Behaviour2> ().speed = speed;
		gustID2.GetComponent<Gust_Behaviour2> ().damage = damage*charge;
		gustID2.GetComponent<Gust_Behaviour2> ().range = range*charge;
		gustID2.GetComponent<Gust_Behaviour2> ().pushStack = pushStack;
		gustID2.GetComponent<Gust_Behaviour2> ().pushback = pushback*charge;
		gustID2.GetComponent<Gust_Behaviour2> ().playerID = playerID; 
		
		playerID.GetComponent<PlayerMovement> ().castingEnd ();
		playerID.transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  castTurnSpeed * Time.deltaTime);
		Destroy (gameObject);
	}

}
