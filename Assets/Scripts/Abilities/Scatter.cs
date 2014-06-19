using UnityEngine;
using System.Collections;

public class Scatter : Ability{
	
	private float castTurnSpeed = 100;
	public float angleBetweenProjectiles = -5;
	public float timeBetweenProjectiles = 2000f;
	public int numberOfProjectiles = 7;
	public float slowBy;
	public float slowTime;

	private int projectileNumber = 1;
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
		angle -= currentAngle;
		Vector2 v = (new Vector2 (Mathf.Cos (angle * Mathf.Deg2Rad), Mathf.Sin (angle * Mathf.Deg2Rad)));
		scatterDir.x = v.x;
		scatterDir.y = v.y;
		
		var ScatterID 					= Instantiate (instance, currentPosition + scatterDir/2, Quaternion.identity) as Transform ;
		ScatterID .GetComponent<Scatter_Behaviour> ().onCast (scatterDir,speed,angle,range);
		ScatterID .GetComponent<Scatter_Behaviour> ().speed = speed;
		ScatterID .GetComponent<Scatter_Behaviour> ().damage = damage;
		ScatterID .GetComponent<Scatter_Behaviour> ().range = range;
		ScatterID .GetComponent<Scatter_Behaviour> ().pushStack = pushStack;
		ScatterID .GetComponent<Scatter_Behaviour> ().pushback = pushback;
		ScatterID .GetComponent<Scatter_Behaviour> ().slowBy = slowBy;
		ScatterID .GetComponent<Scatter_Behaviour> ().slowTime = slowTime;

		if(projectileNumber < numberOfProjectiles)
		{	
			projectileNumber += 1;
			currentAngle -= angleBetweenProjectiles;
			//StartCoroutine(multipleCast());
			Invoke ("instanceCreate", timeBetweenProjectiles);
			playerID.GetComponent<PlayerMovement> ().stopMoving ();
		}

		else
		{
			projectileNumber = 0;
			currentAngle = angleBetweenProjectiles * (numberOfProjectiles / 2f - 0.5f);
			playerID.GetComponent<PlayerMovement> ().castingEnd();
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
		currentAngle = angleBetweenProjectiles * (numberOfProjectiles / 2f - 0.5f);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
