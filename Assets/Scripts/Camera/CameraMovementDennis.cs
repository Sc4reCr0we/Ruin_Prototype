using UnityEngine;
using System.Collections;

public class CameraMovementDennis : MonoBehaviour {
	public Transform target;
	public int Yoffset = 0;
	public int Zoffset = -10;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

		transform.position = target.position + new Vector3(0,Yoffset, Zoffset);
	}
}
