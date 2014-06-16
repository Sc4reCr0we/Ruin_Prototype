using UnityEngine;
using System.Collections;

public class Fireball : Ability{

	private float castTurnSpeed = 100;


	public override void cast(GameObject playerID){
		instanceCreate (playerID);
	}

	public override void instanceCreate(GameObject playerID){
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos 		= Camera.main.ScreenToWorldPoint( Input.mousePosition );
		Vector3 fireballDir		= mousePos - currentPosition;
		fireballDir.z 			= 0;
		fireballDir.Normalize ();
		float angle 			= Mathf.Atan2 (fireballDir.y, fireballDir.x) * Mathf.Rad2Deg;

		var fireballID 					= Instantiate (instance, currentPosition + fireballDir/2, Quaternion.identity) as Transform ;
		fireballID.GetComponent<fireball_behave> ().onCast (fireballDir,speed,angle,range);
		fireballID.GetComponent<fireball_behave> ().speed = speed;
		fireballID.GetComponent<fireball_behave> ().damage = damage;
		fireballID.GetComponent<fireball_behave> ().range = range;
		fireballID.GetComponent<fireball_behave> ().pushStack = pushStack;
		fireballID.GetComponent<fireball_behave> ().pushback = pushback;



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
