using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityCooldowns : MonoBehaviour {

	public UI2DSprite button_1 = null;

	public GameObject playerObject;

	private float cooldownButton_1;

	private float cooldownLeftButton_1;
	
	// time for cool down complete of the annihilation beam
	//public float annhilationBeamCoolDownTime = 0f;

	void start()
	{

	}
		
	// Update is called once per frame
	void Update ()
	{
		cooldownButton_1 = playerObject.GetComponent<slotManager> ().Spc_slot.cooldown;
		cooldownLeftButton_1 = playerObject.GetComponent<slotManager> ().Spc_cooldown;
		button_1.fillAmount = cooldownLeftButton_1 / cooldownButton_1;
	}

}