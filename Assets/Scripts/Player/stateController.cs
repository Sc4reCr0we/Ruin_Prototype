using UnityEngine;
using System.Collections;

public class stateController : MonoBehaviour {

	public bool isSilenced;
	public bool isSlowed;
	public bool isStunned;

	public void setSilence(float duration){
		isSilenced = true;
		gameObject.GetComponent<slotManager>().setCanCast(false);
		Invoke ("removeSilence", duration);
		Debug.Log("Player_silenced");
	}

	public void setSlow (float duration, float amount){
		isSlowed = true;
		gameObject.GetComponent<PlayerMovement>().slowDown(amount);
		Invoke ("removeSlow", duration);
		Debug.Log("Player_slow");
	}

	public void setStun(float duration){
		isStunned = true;
		gameObject.GetComponent<slotManager>().setCanCast(false);
		gameObject.GetComponent<PlayerMovement>().slowDown(100f);
		Invoke ("removeStun", duration);
		Debug.Log("Player_stun");
	}

	public void removeStun(){
		isStunned = false;
		gameObject.GetComponent<PlayerMovement>().setSpeedNormal();
		gameObject.GetComponent<slotManager>().setCanCast(true);
		Debug.Log("Player not stun");
	}

	public void removeSilence(){
		isSilenced = false;
		gameObject.GetComponent<slotManager>().setCanCast(true);
		Debug.Log("Player not silence");
	}

	public void removeSlow(){
		isSlowed = false;
		gameObject.GetComponent<PlayerMovement>().setSpeedNormal();
		Debug.Log("Player not slow");
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
