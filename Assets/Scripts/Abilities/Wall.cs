using UnityEngine;
using System.Collections;

public class Wall : Ability{

	public float duration;
	public float maxHealth;
	private float castTurnSpeed = 100;
	
	
	public override void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		targetPosition = targetPos;
		Invoke ("instanceCreate", casttime);
	}
	
	public override void instanceCreate(){
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos 		= targetPosition;
		Vector3 wallDir		= mousePos - currentPosition;
		wallDir.z 			= 0;
		wallDir.Normalize ();
		float angle 			= Mathf.Atan2 (wallDir.y, wallDir.x) * Mathf.Rad2Deg;
		
		var wallID 					= Instantiate (instance, currentPosition + wallDir * range, Quaternion.identity) as Transform ;
		wallID.GetComponent<Wall_Behaviour> ().playerID = playerID;
		wallID.GetComponent<Wall_Behaviour> ().onCast (duration,maxHealth,angle);
		
		
		
		playerID.transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  castTurnSpeed * Time.deltaTime);
	}
	
	
	
	// Use thiss for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
