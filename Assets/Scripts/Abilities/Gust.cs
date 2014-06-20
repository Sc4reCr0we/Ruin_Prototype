using UnityEngine;
using System.Collections;

public class Gust : Ability{
	private float castTurnSpeed = 100;
	public float MaxChargeTime = 2;
	
	public override void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		targetPosition = targetPos;
		playerID.GetComponent<PlayerMovement> ().slowDown (100, casttime);
		Invoke ("instanceCreate", casttime);
	}
	
	public override void instanceCreate(){
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos 		= targetPosition;
		Vector3 gustDir		= mousePos - currentPosition;
		gustDir.z 			= 0;
		gustDir.Normalize ();
		
		float angle 					= Mathf.Atan2 (gustDir.y, gustDir.x) * Mathf.Rad2Deg;
		var gustID 					= Instantiate (instance, currentPosition + gustDir/2, Quaternion.identity) as Transform ;

		gustID.GetComponent<Gust_Behaviour> ().onCast (MaxChargeTime);
		gustID.GetComponent<Gust_Behaviour> ().speed = speed;
		gustID.GetComponent<Gust_Behaviour> ().damage = damage;
		gustID.GetComponent<Gust_Behaviour> ().range = range;
		gustID.GetComponent<Gust_Behaviour> ().pushStack = pushStack;
		gustID.GetComponent<Gust_Behaviour> ().pushback = pushback;
		gustID.GetComponent<Gust_Behaviour> ().playerID = playerID; 
		gustID.GetComponent<Gust_Behaviour> ().angle = angle; 
		gustID.GetComponent<Gust_Behaviour> ().castTurnSpeed = castTurnSpeed; 
		
		playerID.GetComponent<PlayerMovement> ().castingEnd ();
		playerID.transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  castTurnSpeed * Time.deltaTime);
	}
	
	void stopMoving()
	{
	}
	
	// Use thiss for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
