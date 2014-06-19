using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityCooldowns : MonoBehaviour {

	public UI2DSprite button_1 = null;
	public UI2DSprite button_2 = null;
	public UI2DSprite button_3 = null;

	public GameObject playerObject;

	private float cooldownButton_1;
	private float cooldownButton_2;
	private float cooldownButton_3;

	private float cooldownLeftButton_1;
	private float cooldownLeftButton_2;
	private float cooldownLeftButton_3;
	
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

		cooldownButton_2 = playerObject.GetComponent<slotManager> ().Q_slot.cooldown;
		cooldownLeftButton_2 = playerObject.GetComponent<slotManager> ().Q_cooldown;
		button_2.fillAmount = cooldownLeftButton_2 / cooldownButton_2;

		cooldownButton_3 = playerObject.GetComponent<slotManager> ().E_slot.cooldown;
		cooldownLeftButton_3 = playerObject.GetComponent<slotManager> ().E_cooldown;
		button_3.fillAmount = cooldownLeftButton_3 / cooldownButton_3;
	}

}