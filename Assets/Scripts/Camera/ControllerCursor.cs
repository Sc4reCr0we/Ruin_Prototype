﻿using UnityEngine;
using System.Collections;

public class ControllerCursor : MonoBehaviour {
	public float sens;
	public float range;
	public GameObject player;
	private Vector3 direction;
	public Vector3 lastDirection;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{

		direction = new Vector3 (0, 0, 0);
		direction.x += Input.GetAxis ("ControllerCursor_Horizontal");
		direction.y += Input.GetAxis ("ControllerCursor_Vertical");
		if(direction == Vector3.zero)
			direction = lastDirection;
		lastDirection = direction;
		transform.position = player.transform.position + direction.normalized*range;


	}
}
