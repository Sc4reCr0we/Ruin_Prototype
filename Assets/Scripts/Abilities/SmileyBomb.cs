using UnityEngine;
using System.Collections;

public class SmileyBomb : Ability{

	public float timer;
	public float explTimer;
	private float castTurnSpeed = 100;
	
	
	public override void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		targetPosition = targetPos;
		targetPosition.z = 0f;
		Invoke ("instanceCreate", casttime);
	}
	
	public override void instanceCreate(){
		var smileyBombID 	= Instantiate (instance, targetPosition, Quaternion.identity) as Transform ;

		smileyBombID.GetComponent<SmileyBomb_Behaviour> ().onCast (timer);
		smileyBombID.GetComponent<SmileyBomb_Behaviour> ().damage = damage;
		smileyBombID.GetComponent<SmileyBomb_Behaviour> ().pushStack = pushStack;
		smileyBombID.GetComponent<SmileyBomb_Behaviour> ().pushback = pushback;
		smileyBombID.GetComponent<SmileyBomb_Behaviour> ().explTimer = explTimer;
		/*
		smileyBombID.GetComponent<Fireball_Behaviour> ().speed = speed;
		smileyBombID.GetComponent<Fireball_Behaviour> ().range = range;


		
		
		playerID.transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  castTurnSpeed * Time.deltaTime);
		 */
	}
	
	
	
	// Use thiss for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
