using UnityEngine;
using System.Collections;

public class Teleport : Ability{
	
	private float castTurnSpeed = 100;
	
	
	public override void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		targetPosition = targetPos;
		Invoke ("instanceCreate", casttime);
	}
	
	public override void instanceCreate(){
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos 		= targetPosition;
		Vector3 teleportDir		= mousePos - currentPosition;
		teleportDir.z 			= 0;
		teleportDir.Normalize ();
		float angle 			= Mathf.Atan2 (teleportDir.y, teleportDir.x) * Mathf.Rad2Deg;
		
		var teleportID 					= Instantiate (instance, currentPosition + teleportDir * range, Quaternion.identity) as Transform ;
		teleportID.GetComponent<Teleport_Behaviour> ().playerID = playerID;
		
		
		
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
