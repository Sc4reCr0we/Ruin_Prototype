using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthPushbackBar : MonoBehaviour {
		
	public UI2DSprite healthbar = null;
	public UI2DSprite pushbackbar = null;
	
	public GameObject playerObject;
	
	private float healthMax;	
	private float healthCurrent;

	private float pushbackMax;	
	private float pushbackCurrent;


	
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

		pushbackMax = playerObject.GetComponent<PushbackScript> ().maxStack;
		pushbackCurrent = playerObject.GetComponent<PushbackScript> ().pushStack;
		pushbackbar.fillAmount = pushbackCurrent / pushbackMax;
	}
		
}