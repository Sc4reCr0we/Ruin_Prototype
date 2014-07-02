using UnityEngine;
using System.Collections;

public class stateController : MonoBehaviour {

	public bool isSilenced;
	public bool isSlowed;
	public bool isStunned;

	public Object stun;
	public Object slow;
	public Object silence;

	public float slowTime;
	public float silenceTime;
	public float stunTime;

	private GameObject stunTemp;
	private GameObject slowTemp;
	private GameObject silenceTemp;



	public void setSilence(float duration){
		isSilenced = true;
		gameObject.GetComponent<slotManager>().setCanCast(false);
		silenceTemp = Instantiate (silence, transform.position, Quaternion.identity) as GameObject;
		silenceTemp.GetComponent<abovePlayer>().playerObject = gameObject;
		Invoke ("removeSilence", duration);
		Debug.Log("Player_silenced");
	}

	public void setSlow (float duration, float amount){
		Debug.Log("Player_slow");
		isSlowed = true;
		gameObject.GetComponent<PlayerMovement>().slowDown(amount);
		slowTime += duration;
	}

	public void setStun(float duration){
		isStunned = true;
		gameObject.GetComponent<slotManager>().setCanCast(false);
		gameObject.GetComponent<PlayerMovement>().slowDown(100f);
		stunTemp = Instantiate (stun, transform.position, Quaternion.identity) as GameObject;
		stunTemp.GetComponent<abovePlayer>().playerObject = gameObject;
		Invoke ("removeStun", duration);
		Debug.Log("Player_stun");
	}

	public void removeStun(){
		isStunned = false;
		gameObject.GetComponent<PlayerMovement>().setSpeedNormal();
		gameObject.GetComponent<slotManager>().setCanCast(true);
		Destroy (stunTemp);
		Debug.Log("Player not stun");
	}

	public void removeSilence(){
		isSilenced = false;
		gameObject.GetComponent<slotManager>().setCanCast(true);
		Destroy (silenceTemp);
		Debug.Log("Player not silence");
	}

	public void removeSlow(){
		isSlowed = false;
		gameObject.GetComponent<PlayerMovement>().setSpeedNormal();
		Debug.Log("Player not slow");
	}

	private void slowCount(){
		if (isSlowed){
			if (slowTime > 0) {
				slowTime -= 1*Time.deltaTime;
			}
			else if(slowTime < 0 || slowTime == 0){
				removeSlow();
				slowTime =0f;
			}
		}
	}

	private void silenceCount(){
		if (isSilenced){
			if (silenceTime > 0) {
				silenceTime -= 1*Time.deltaTime;
			}
			else if(silenceTime < 0){
				removeSilence();
				silenceTime =0f;
			}
		}
	}

	private void stunCount(){
		if (isStunned){
			if (stunTime > 0) {
				stunTime -= 1*Time.deltaTime;
			}
			else if(stunTime < 0){
				removeStun();
				stunTime =0f;
			}
		}
	}

	// Use this for initialization
	void Start () {
		slowTime 	= 0f;
		silenceTime = 0f;
		stunTime 	= 0f;
	}
	
	// Update is called once per frame
	void Update () {
		slowCount ();
		stunCount ();
		silenceCount ();
	}
}
