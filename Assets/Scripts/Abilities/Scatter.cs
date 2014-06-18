using UnityEngine;
using System.Collections;

public class Scatter : Ability{
	
	private float castTurnSpeed = 100;
	public float angleBetweenProjectiles = -10;
	public float timeBetweenProjectiles = 5f;
	public int numberOfProjectiles = 7;

	private int projectileNumber = 0;
	private float currentAngle; 
	
	
	public override void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		targetPosition = targetPos;
		Invoke ("instanceCreate", casttime);

	}
	
	public override void instanceCreate(){
		Vector3 currentPosition = playerID.transform.position;
		Vector3 mousePos 		= targetPosition;
		Vector3 scatterDir		= mousePos - currentPosition;
		scatterDir.z 			= 0;
		scatterDir.Normalize ();
		float angle 			= Mathf.Atan2 (scatterDir.y, scatterDir.x) * Mathf.Rad2Deg;
		angle -= angleBetweenProjectiles;
		Vector2 v = (new Vector2 (Mathf.Cos (angle * Mathf.Deg2Rad), Mathf.Sin (angle * Mathf.Deg2Rad)));
		scatterDir.x = v.x;
		scatterDir.y = v.y;
		
		var fireballID 					= Instantiate (instance, currentPosition + scatterDir/2, Quaternion.identity) as Transform ;
		fireballID.GetComponent<Fireball_Behaviour> ().onCast (scatterDir,speed,angle,range);
		fireballID.GetComponent<Fireball_Behaviour> ().speed = speed;
		fireballID.GetComponent<Fireball_Behaviour> ().damage = damage;
		fireballID.GetComponent<Fireball_Behaviour> ().range = range;
		fireballID.GetComponent<Fireball_Behaviour> ().pushStack = pushStack;
		fireballID.GetComponent<Fireball_Behaviour> ().pushback = pushback;

		if(projectileNumber < numberOfProjectiles)
		{	
			projectileNumber += 1;
			currentAngle -= angleBetweenProjectiles;
			Invoke ("castAgain", timeBetweenProjectiles);
		}

		else
		{
			projectileNumber = 0;
			currentAngle = angleBetweenProjectiles;
		}
		
		
		playerID.transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  castTurnSpeed * Time.deltaTime);
	}



	// Use thiss for initialization
	void Awake () {
		
	}

	void Start() {
		currentAngle = angleBetweenProjectiles;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
