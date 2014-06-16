using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthPushbackBar : MonoBehaviour {
		
	public UI2DSprite healthbar = null;
	
	public GameObject playerObject;
	
	private float healthMax;
	
	private float healthCurrent;
	
	// time for cool down complete of the annihilation beam
	//public float annhilationBeamCoolDownTime = 0f;
	
	void start()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		healthMax = playerObject.GetComponent<HealthScript> ().maxHealth;
		healthCurrent = playerObject.GetComponent<HealthScript> ().health;
		healthbar.fillAmount = healthCurrent / healthMax;
	}
		
}