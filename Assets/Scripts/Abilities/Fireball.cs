using UnityEngine;
using System.Collections;

public class Fireball : Ability{

	private float castTurnSpeed = 100;


	public override void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		targetPosition = targetPos;
		Invoke ("instanceCreate", casttime);
	}

	public override void instanceCreate(){
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos 		= targetPosition;
		Vector3 fireballDir		= mousePos - currentPosition;
		fireballDir.z 			= 0;
		fireballDir.Normalize ();

		float angle 			= Mathf.Atan2 (fireballDir.y, fireballDir.x) * Mathf.Rad2Deg;
		var fireballID 					= Instantiate (instance, currentPosition + fireballDir/2, Quaternion.identity) as Transform ;
		fireballID.GetComponent<Fireball_Behaviour> ().onCast (fireballDir,speed,angle,range);
		fireballID.GetComponent<Fireball_Behaviour> ().speed = speed;
		fireballID.GetComponent<Fireball_Behaviour> ().damage = damage;
		fireballID.GetComponent<Fireball_Behaviour> ().range = range;
		fireballID.GetComponent<Fireball_Behaviour> ().pushStack = pushStack;
		fireballID.GetComponent<Fireball_Behaviour> ().pushback = pushback;



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
