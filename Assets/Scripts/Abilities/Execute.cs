using UnityEngine;
using System.Collections;

public class Execute : Ability{
	
	private float castTurnSpeed = 100;
	public float instakillPercentage = 20f;
	
	public override void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		targetPosition = targetPos;
		playerID.GetComponent<PlayerMovement> ().slowDown (100, casttime);
		Invoke ("instanceCreate", casttime);
	}
	
	public override void instanceCreate(){
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos 		= targetPosition;
		Vector3 executeDir		= mousePos - currentPosition;
		executeDir.z 			= 0;
		executeDir.Normalize ();
		
		float angle 					= Mathf.Atan2 (executeDir.y, executeDir.x) * Mathf.Rad2Deg;
		var executeID 					= Instantiate (instance, currentPosition + executeDir/2, Quaternion.identity) as Transform ;
		executeID.GetComponent<Execute_Behaviour> ().onCast (executeDir,speed,angle,range);
		executeID.GetComponent<Execute_Behaviour> ().speed = speed;
		executeID.GetComponent<Execute_Behaviour> ().damage = damage;
		executeID.GetComponent<Execute_Behaviour> ().range = range;
		executeID.GetComponent<Execute_Behaviour> ().pushStack = pushStack;
		executeID.GetComponent<Execute_Behaviour> ().pushback = pushback;
		executeID.GetComponent<Execute_Behaviour> ().playerID = playerID; 
		executeID.GetComponent<Execute_Behaviour> ().instakillPercentage = instakillPercentage/100;
		executeID.GetComponent<Execute_Behaviour> ().angle = angle; 

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
