using UnityEngine;
using System.Collections;

public class Reflect : Ability{
	
	private float castTurnSpeed = 100;
	public float duration = 3; 
	
	
	public override void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		targetPosition = targetPos;
		Invoke ("instanceCreate", casttime);
	}
	
	public override void instanceCreate(){
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos 		= targetPosition;
		Vector3 reflectDir		= mousePos - currentPosition;
		reflectDir.z 			= 0;
		reflectDir.Normalize ();
		
		float angle 			= Mathf.Atan2 (reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
		var reflectID 					= Instantiate (instance, playerID.transform.position, Quaternion.identity) as Transform ;
		reflectID.GetComponent<Reflect_Behaviour> ().onCast (duration, playerID);
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
