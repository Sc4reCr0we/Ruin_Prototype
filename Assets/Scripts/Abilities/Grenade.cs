using UnityEngine;
using System.Collections;

public class Grenade : Ability{
	
	private float castTurnSpeed = 100;
	public float time;
	public float timer;
	
	
	public override void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		targetPosition = targetPos;
		Invoke ("instanceCreate", casttime);
	}
	
	public override void instanceCreate(){
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos 		= targetPosition;
		Vector3 grenadeDir		= mousePos - currentPosition;
		grenadeDir.z 			= 0;
		grenadeDir.Normalize ();
		currentPosition.z = 0f;
		mousePos.z = 0f;
		range = Vector2.Distance(targetPosition, currentPosition);
		
		float angle 			= Mathf.Atan2 (grenadeDir.y, grenadeDir.x) * Mathf.Rad2Deg;
		var grenadeID 					= Instantiate (instance, currentPosition + grenadeDir/2, Quaternion.identity) as Transform ;
		grenadeID.GetComponent<Grenade_Behaviour> ().onCast (grenadeDir, angle, range, time);
		grenadeID.GetComponent<Grenade_Behaviour> ().time = time;
		grenadeID.GetComponent<Grenade_Behaviour> ().damage = damage;
		grenadeID.GetComponent<Grenade_Behaviour> ().range = range;
		grenadeID.GetComponent<Grenade_Behaviour> ().pushStack = pushStack;
		grenadeID.GetComponent<Grenade_Behaviour> ().pushback = pushback;
		grenadeID.GetComponent<Grenade_Behaviour> ().timer = timer;
		
		
		
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
