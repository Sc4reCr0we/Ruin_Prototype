using UnityEngine;
using System.Collections;

public class EMP : Ability{

	public float SilenceDuration;
	private float castTurnSpeed = 100;
	public float killTimer = 2;
	
	
	public override void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		Invoke ("instanceCreate", casttime);
	}
	
	public override void instanceCreate(){
		var EMPID 	= Instantiate (instance, playerID.transform.position, Quaternion.identity) as Transform ;

		EMPID.GetComponent<EMP_Behaviour> ().onCast (SilenceDuration,playerID);
		EMPID.GetComponent<EMP_Behaviour> ().setDestroyTimer (killTimer);

	}
	
	// Use thiss for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
