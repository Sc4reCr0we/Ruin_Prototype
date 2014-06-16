using UnityEngine;
using System.Collections;

public class ElectricityGenerator : MonoBehaviour {
	private Vector3 electricityPosition;
	public GameObject electricityObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		electricityPosition = Random.insideUnitCircle * 37.5f;
		electricityPosition.z = 0;
		Quaternion randomRotation = Random.rotation;
		randomRotation.x = 0;
		randomRotation.y = 0;
		Instantiate (electricityObject, electricityPosition, randomRotation);
	}
}
