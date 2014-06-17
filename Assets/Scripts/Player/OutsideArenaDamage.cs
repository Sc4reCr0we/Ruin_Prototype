using UnityEngine;
using System.Collections;

public class OutsideArenaDamage : MonoBehaviour {
	public float damagePerSecond;

	public bool isOutside = false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isOutside)
			GetComponent<HealthScript>().setHealth (-damagePerSecond * Time.deltaTime);	
	}
	
}
