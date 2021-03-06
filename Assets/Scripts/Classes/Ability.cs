﻿using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour{

	// Variables for each ability
	public float casttime;
	public float cooldown;
	public float range;
	public float speed;
	public float damage;
	public float pushback;
	public float pushStack;
	public Vector3 targetPosition;
	public bool smartCast = false;
	public Sprite iconSprite;

	private bool _isReady = true;

	public bool isReady{ get{ return _isReady; } set {_isReady = value;} }

	public bool isCast;

	public Transform instance;

	public GameObject playerID;
	
	public void setReady(bool ready){
		isReady = ready;

	}

	public virtual void cast(GameObject playerID1, Vector3 targetPos){
		playerID = playerID1;
		targetPosition = targetPos;
		Invoke("instanceCreate", casttime);
	}

	public virtual void instanceCreate(){
		var castedAbility = Instantiate(instance) as Transform;
		castedAbility.position = playerID.transform.position;
	}
	// Use this for initialization
	void Awake () {
		isReady = true;
		casttime = 0.2f;
	}

}
