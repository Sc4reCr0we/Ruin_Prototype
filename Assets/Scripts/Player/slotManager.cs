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

	public string QKey = "Qkey";
	public string EKey = "Ekey";
	public string RKey = "Rkey";
	public string SpaceKey = "Spacekey";
	public string fireAbility = "Mouse1";

	public Vector3 targetPosition;
	public Transform player2Cursor;
	public int playerNumber;

	public bool GamePad;
	public bool canCast = true;

	private Ability currentSlot;
	private Animator animator;
	private bool isSmartCast;
	private bool Q_shoot;
	private bool E_shoot;
	private bool R_shoot;
	private bool Spc_shoot;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	public void setCanCast(bool cancast){
		canCast = cancast;
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


	private bool gamepadDown(string button){
		if(Input.GetAxis (button) > 0.5f){

			return true;
		}
		else if (Input.GetAxis (button) < 0.5f){

			isSmartCast = false;
			return false;
		}
		else
			return false;
	}

	private void setActiveSlot(){

		if (!GamePad){
		// Check each button for press and set the current slot correspondingly
			Q_shoot		= Input.GetButtonDown (QKey);
			E_shoot 	= Input.GetButtonDown(EKey);
			Spc_shoot 	= Input.GetButtonDown(SpaceKey);
			R_shoot 	= Input.GetButtonDown(RKey);
		}
		else if(GamePad){
			Q_shoot 	= gamepadDown (QKey);
			E_shoot 	= gamepadDown (EKey);
			Spc_shoot 	= gamepadDown (SpaceKey);
			R_shoot 	= gamepadDown (RKey);
		}
		if(R_shoot == true){
			slotNumb = 1;
			currentSlot = R_slot;
			Q_shoot = false;
			E_shoot = false;
			Spc_shoot = false;
			if(!isSmartCast)
			isSmartCast = true;
		}
		else if(Q_shoot == true){
			slotNumb = 2;
			currentSlot = Q_slot;
			R_shoot = false;
			E_shoot = false;
			Spc_shoot = false;
			if(!isSmartCast)
			isSmartCast = true;
		}
		else if(E_shoot == true){
			slotNumb = 3;
			currentSlot = E_slot;
			R_shoot = false;
			Q_shoot = false;
			Spc_shoot = false;
			if(!isSmartCast)
			isSmartCast = true;
		}
		else if(Spc_shoot == true){
			slotNumb = 4;
			currentSlot = Spc_slot;
			Q_shoot = false;
			E_shoot = false;
			R_shoot = false;
			if(!isSmartCast)
			isSmartCast = true;
		}
	}

	private void castdelay(){
		currentSlot.cast(gameObject, targetPosition);
	}

	public Vector3 targetPos(){
		if(playerNumber == 1){
			return Camera.main.ScreenToWorldPoint( Input.mousePosition );
		}
		else if(playerNumber == 2){
			return  player2Cursor.position;
		}
		else{
			return Vector3.zero;
		}
	}


	// Update is called once per frame
	void Update () {
		//Smartcast for controller, fullösning



		setActiveSlot ();
		cooldownCount ();
		checkCooldown ();
		if (currentSlot != null) {
			if(Input.GetButtonDown(fireAbility) && currentSlot.isReady && canCast){
				currentSlot.setReady(false);
				setCooldown();
				animator.SetBool ("casting", true);
				if(playerNumber == 1)
					targetPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
				if(playerNumber == 2)
					targetPosition = player2Cursor.position;
				castdelay();
			}
			else if (currentSlot.smartCast && isSmartCast && currentSlot.isReady && canCast){
				currentSlot.setReady(false);
				isSmartCast = false;
				setCooldown();
				animator.SetBool ("casting", true);
				if(playerNumber == 1)
					targetPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
				if(playerNumber == 2)
					targetPosition = player2Cursor.position;
				castdelay();

			}

		}
	}
}
