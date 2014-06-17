using UnityEngine;
using System.Collections;

public class slotManager : MonoBehaviour {
	
	public Ability Q_slot;
	public Ability E_slot;
	public Ability R_slot;
	public Ability Spc_slot;
	private int slotNumb;

	public float Q_cooldown = 0;
	public float E_cooldown = 0;
	public float R_cooldown = 0;
	public float Spc_cooldown = 0;

	private Ability currentSlot;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	public void checkCooldown(){
		if (Q_cooldown < 0 && !Q_slot.isReady) {
			Q_slot.setReady (true);
		}
		
		if (E_cooldown < 0 && !E_slot.isReady)
		{
			E_slot.setReady (true);
		}
		
		if (R_cooldown < 0 && !R_slot.isReady)
		{
			R_slot.setReady (true);
		}
		
		if (Spc_cooldown < 0 && !Spc_slot.isReady)
		{
			Spc_slot.setReady (true);
		}
	}

	public void cooldownCount(){
		if (Q_cooldown > 0) {
			Q_cooldown -= Time.deltaTime;
		}

		if (E_cooldown > 0)
		{
			E_cooldown -= Time.deltaTime;
		}

		if (R_cooldown > 0)
		{
			R_cooldown -= Time.deltaTime;
		}

		if (Spc_cooldown > 0)
		{
			Spc_cooldown -= Time.deltaTime;
		}
	}

	public void setCooldown(){
		if (slotNumb!=null){
			switch(slotNumb){
				case 1:
					R_cooldown = R_slot.cooldown;
					break;
				case 2:
					Q_cooldown = Q_slot.cooldown;
					break;
				case 3:
					E_cooldown = E_slot.cooldown;
					break;
				case 4:
					Spc_cooldown = Spc_slot.cooldown;
					break;
			}
		}
	}

	private void setActiveSlot(){
		// Check each button for press and set the current slot correspondingly
		bool Q_shoot = Input.GetButtonDown("Qkey");
		bool E_shoot = Input.GetButtonDown("Ekey");
		bool R_shoot = Input.GetButtonDown("Rkey");
		bool Spc_shoot = Input.GetButtonDown("Space");
		
		if(R_shoot == true){
			slotNumb = 1;
			currentSlot = R_slot;
			Q_shoot = false;
			E_shoot = false;
			Spc_shoot = false;
		}
		else if(Q_shoot == true){
			slotNumb = 2;
			currentSlot = Q_slot;
			R_shoot = false;
			E_shoot = false;
			Spc_shoot = false;
		}
		else if(E_shoot == true){
			slotNumb = 3;
			currentSlot = E_slot;
			R_shoot = false;
			Q_shoot = false;
			Spc_shoot = false;
		}
		else if(Spc_shoot == true){
			slotNumb = 4;
			currentSlot = Spc_slot;
			Q_shoot = false;
			E_shoot = false;
			R_shoot = false;
		}
	}

	private void castdelay(){
		currentSlot.cast(gameObject);
		}


	// Update is called once per frame
	void Update () {
		setActiveSlot ();
		cooldownCount ();
		checkCooldown ();
		if (currentSlot != null) {

			if(Input.GetButtonDown("Fire1") && currentSlot.isReady){
				setCooldown();
				currentSlot.setReady(false);
				animator.SetBool ("casting", true);
				Invoke("castdelay",0.2f);
			}

		}
	}
}
