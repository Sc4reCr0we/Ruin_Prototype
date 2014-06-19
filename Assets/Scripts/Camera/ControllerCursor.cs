using UnityEngine;
using System.Collections;

public class ControllerCursor : MonoBehaviour {
	public float sens;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = new Vector3(0,0,0);
		direction.x += Input.GetAxis ("ControllerCursor_Horizontal");
		direction.y += Input.GetAxis ("ControllerCursor_Vertical");
		rigidbody2D.velocity = direction.normalized*sens*Time.deltaTime;

	}
}
